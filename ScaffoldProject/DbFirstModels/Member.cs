using System;
using System.Collections.Generic;

namespace ScaffoldProject.DbFirstModels;

public partial class Member
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime RegisterDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
}
