using CoreLibrary.Models;
using CoreLibrary.Repositories;
using System.Collections.Generic;

namespace CoreLibrary.Services;

public class DepartmentService : IDataService<Department>
{
    private readonly IRepository<Department> _departmentRepository;

    public DepartmentService(IRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public void AddItem(Department item)
    {
        _departmentRepository.AddItem(item);
    }

    public void UpdateItem(Department item)
    {
        _departmentRepository.UpdateItem(item);
    }

    public void DeleteItem(string id)
    {
        _departmentRepository.DeleteItem(id);
    }

    public Department GetItem(string id)
    {
        return _departmentRepository.GetItem(id);
    }

    public ICollection<Department> GetItems()
    {
        return _departmentRepository.GetItems();
    }
}
