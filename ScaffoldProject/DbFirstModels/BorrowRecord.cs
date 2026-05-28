using System;
using System.Collections.Generic;

namespace ScaffoldProject.DbFirstModels;

public partial class BorrowRecord
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public string BookTitle { get; set; } = null!;

    public DateTime BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public bool IsReturned { get; set; }

    public virtual Member Member { get; set; } = null!;
}
