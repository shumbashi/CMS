using Application.Interfaces.Common;
using Domain.Common;
using Infrastructure.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Common
{
    /// <summary>
    /// مستودع عام (Generic Repository) لتنفيذ عمليات CRUD والاستعلامات الشائعة
    /// </summary>
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly ServiceDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(ServiceDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        /// <summary>البحث باستخدام شرط وإرجاع قائمة العناصر</summary>
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        /// <summary>إضافة عنصر جديد (غير متزامن)</summary>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        /// <summary>إضافة مجموعة من العناصر دفعة واحدة</summary>
        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        /// <summary>تحديث عنصر واحد</summary>
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>تحديث مجموعة عناصر دفعة واحدة</summary>
        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        /// <summary>حذف عنصر</summary>
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>حذف مجموعة عناصر دفعة واحدة</summary>
        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /// <summary>الحصول على عنصر بواسطة الـ Id</summary>
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// الحصول على عنصر بواسطة Id مع جلب (Include) للعلاقات المحددة
        /// </summary>
        public async Task<T?> GetByIdAsync(Guid id, string[] includes)
        {
            var query = _dbSet.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>الحصول على جميع العناصر</summary>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>إرجاع عدد العناصر</summary>
        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        /// <summary>إرجاع عدد العناصر وفق شرط معين</summary>
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
        }

        /// <summary>إرجاع عدد كبير (long) لجميع العناصر</summary>
        public async Task<long> LongCountAsync()
        {
            return await _dbSet.LongCountAsync();
        }

        /// <summary>إرجاع عدد كبير (long) وفق شرط معين</summary>
        public async Task<long> LongCountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.LongCountAsync(predicate);
        }

        /// <summary>البحث باستخدام شرط وإرجاع IQueryable (يُتيح المزيد من المعالجة قبل التنفيذ)</summary>
        public IQueryable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        /// <summary>إرجاع العناصر المطابقة لشرط معين مرتبة تنازلياً حسب تاريخ الإنشاء</summary>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).OrderByDescending(t => t.CreatedDate);
        }

        /// <summary>إرجاع عنصر واحد يطابق شرط معين</summary>
        public async Task<T?> FindOneByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// التحقق إن كان نوع الخاصية نصّي (string)
        /// </summary>
        public bool TypeProperty(object obj, string propertyName)
        {
            var propInfo = obj.GetType().GetProperty(propertyName);
            return propInfo?.PropertyType == typeof(string);
        }

     

        /// <summary>التحقق من وجود عنصر بواسطة Id</summary>
        public async Task<bool> IsExistAsync(Guid id)
        {
            return await GetByIdAsync(id) != null;
        }

        /// <summary>التحقق إن كان هناك اعتماد (Dependency) على عنصر معين</summary>
        public async Task<bool> IsDependentAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().AnyAsync(predicate);
        }

        /// <summary>
        /// التحقق أو التحقق المخصص (Validation) – يمكن إعادة تعريفها في المستودعات المشتقة
        /// </summary>
        public virtual Task<List<string>> VerifyEntityAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
