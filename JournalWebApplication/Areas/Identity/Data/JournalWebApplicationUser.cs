using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalApiApp.Model.Entities.Access;
using Microsoft.AspNetCore.Identity;

namespace JournalWebApplication.Areas.Identity.Data;

// Add profile data for application users by adding properties to the JournalWebApplicationUser class
public class JournalWebApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Adress { get; set; }
}

