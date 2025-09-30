using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public DateOnly? JoinDate { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
}
