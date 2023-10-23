using System;
using System.Collections.Generic;

namespace WestWindSystem.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? TitleOfCourtesy { get; set; }

    public string? JobTitle { get; set; }

    public int? ReportsTo { get; set; }

    public DateTime HireDate { get; set; }

    public string? OfficePhone { get; set; }

    public string? Extension { get; set; }

    public DateTime BirthDate { get; set; }

    public int AddressId { get; set; }

    public string HomePhone { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public string? PhotoMimeType { get; set; }

    public string? Notes { get; set; }

    public bool? Active { get; set; }

    public DateTime? TerminationDate { get; set; }

    public bool OnLeave { get; set; }

    public string? LeaveReason { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Employee? ReportsToNavigation { get; set; }

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
