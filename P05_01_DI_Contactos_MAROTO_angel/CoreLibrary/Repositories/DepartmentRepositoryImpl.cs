using CoreLibrary.Data;
using CoreLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreLibrary.Repositories
{
    public class DepartmentRepositoryImpl : IRepository<Department>
    {
        private readonly AppDbContext context;

        public DepartmentRepositoryImpl(AppDbContext context)
        {
            this.context = context;
        }

        public Department AddItem(Department item)
        {
            context.Departments.Add(item);
            context.SaveChanges();
            return item;
        }

        public Department? GetItem(string name)
        {
            return context.Departments.FirstOrDefault(d => d.Name == name);
        }

        public bool DeleteItem(string name)
        {
            var department = context.Departments.FirstOrDefault(d => d.Name == name);

            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public Department? UpdateItem(Department item)
        {
            var existingDepartment = context.Departments.FirstOrDefault(d => d.Name == item.Name);

            if (existingDepartment != null)
            {
                context.Departments.Remove(existingDepartment);
                context.SaveChanges();

                context.Departments.Add(item);
                context.SaveChanges();

                return item;
            }

            return null;
        }

        public List<Department> GetItems()
        {
            return context.Departments.ToList();
        }

        public void ClearItems()
        {
            var allDepartments = context.Departments.ToList();
            context.Departments.RemoveRange(allDepartments);
            context.SaveChanges();
        }
    }
}
