using CoreLibrary.Models;
using CoreLibrary.Repositories;
using System.Collections.Generic;

namespace CoreLibrary.Services;

public class EmployeeService : IDataService<Employee>
{
    private readonly IRepository<Employee> _employeeRepository;

    public EmployeeService(IRepository<Employee> employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public void AddItem(Employee item)
    {
        _employeeRepository.AddItem(item);
    }

    public void UpdateItem(Employee item)
    {
        _employeeRepository.UpdateItem(item);
    }

    public void DeleteItem(string id)
    {
        _employeeRepository.DeleteItem(id);
    }

    public Employee GetItem(string id)
    {
        return _employeeRepository.GetItem(id);
    }

    public ICollection<Employee> GetItems()
    {
        return _employeeRepository.GetItems();
    }
}

