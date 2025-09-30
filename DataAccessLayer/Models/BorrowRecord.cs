using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class BorrowRecord
{
    public int BorrowId { get; set; }

    public int? MemberId { get; set; }

    public int? BookId { get; set; }

    public DateOnly BorrowDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Member? Member { get; set; }
}
