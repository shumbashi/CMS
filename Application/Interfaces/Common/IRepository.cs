using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Common
{
    public interface IRepository<T> where T : class, IEntity
    {
        // الحصول على عنصر بواسطة Id
        Task<T?> GetByIdAsync(Guid id);

        // الحصول على عنصر بواسطة Id مع جلب العلاقات المحددة
        Task<T?> GetByIdAsync(Guid id, string[] includes);

        // الحصول على كل العناصر
        Task<IEnumerable<T>> GetAllAsync();

        // البحث باستخدام شرط
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // إضافة عنصر جديد
        Task AddAsync(T entity);

        // تحديث عنصر
        void Update(T entity);

        // تحديث مجموعة عناصر
        void UpdateRange(IEnumerable<T> entities);

        // حذف عنصر
        void Delete(T entity);

        // حذف مجموعة عناصر
        void DeleteRange(IEnumerable<T> entities);

        // إضافة مجموعة عناصر
        void AddRange(IEnumerable<T> entities);

        // إرجاع عدد العناصر
        Task<int> CountAsync();

        // إرجاع عدد العناصر وفق شرط معين
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        // إرجاع عدد كبير (long) لجميع العناصر
        Task<long> LongCountAsync();

        // إرجاع عدد كبير (long) وفق شرط معين
        Task<long> LongCountAsync(Expression<Func<T, bool>> predicate);

        // إرجاع العناصر المطابقة لشرط معين مرتبة حسب تاريخ الإنشاء
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate);

        // إرجاع عنصر واحد يطابق شرط معين
        Task<T?> FindOneByConditionAsync(Expression<Func<T, bool>> predicate);

        // إرجاع العناصر كمجموعة IQueryable
        IQueryable<T> List(Expression<Func<T, bool>> predicate);

        // التحقق من وجود عنصر بواسطة Id
        Task<bool> IsExistAsync(Guid id);

        // التحقق إن كان هناك اعتماد (Dependency) على عنصر معين
        Task<bool> IsDependentAsync(Expression<Func<T, bool>> predicate);

        // التحقق أو التحقق المخصص (Validation)
        Task<List<string>> VerifyEntityAsync(T entity);
    }
}
