using CoreLibrary.Data;
using CoreLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreLibrary.Repositories;

public class EmployeeRepositoryImpl : IRepository<Employee>
{
    private readonly AppDbContext context;

    public EmployeeRepositoryImpl(AppDbContext context)
    {
        this.context = context;
    }

    public Employee? AddItem(Employee item)
    {
        if (GetItem(item.Dni) == null)
        {
            context.Employees.Add(item);
            context.SaveChanges();
            return item;
        }
        return null;
    }

    public Employee? GetItem(string dni)
    {
        return context.Employees.FirstOrDefault(e => e.Dni == dni);
    }

    public bool DeleteItem(string dni)
    {
        var employee = context.Employees.FirstOrDefault(e => e.Dni == dni);

        if (employee != null)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
            return true;
        }

        return false;
    }

    public Employee? UpdateItem(Employee item)
    {
        var existingEmployee = context.Employees.FirstOrDefault(e => e.Dni == item.Dni);

        if (existingEmployee != null)
        {
            context.Employees.Remove(existingEmployee);
            context.SaveChanges();

            context.Employees.Add(item);
            context.SaveChanges();

            return item;
        }

        return null;
    }

    public List<Employee> GetItems()
    {
        return context.Employees
        .Select(e =>
            new Employee
            (
                e.Dni,
                e.DepartmentName ?? "",
                e.Name,
                e.Email,
                e.Phone,
                e.Position,
                e.Image
            )
        )
        .ToList();
    }

    public void ClearItems()
    {
        var allEmployees = context.Employees.ToList();
        context.Employees.RemoveRange(allEmployees);
        context.SaveChanges();
    }
}
