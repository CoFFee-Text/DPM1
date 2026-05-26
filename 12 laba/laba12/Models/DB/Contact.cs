using System;
using System.Collections.Generic;

namespace laba12.Models.DB;

public partial class Contact
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;
}