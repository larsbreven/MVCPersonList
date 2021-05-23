using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.ViewModel
{
    public class RolesManagementVM
    {
        public string UserId { get; set; }

        public IList<string> UserRoles { get; set; }

        public List<IdentityRole> IdentityRoles { get; set; }

        public RolesManagementVM(string userId, IList<string> userRoles, List<IdentityRole> identityRoles)
        {
            UserId = userId;
            UserRoles = userRoles;
            IdentityRoles = identityRoles;
            FilterRoles();
        }

        void FilterRoles()
        {
            foreach (string item in UserRoles)
            {
                IdentityRoles.Remove(IdentityRoles.Single(row => row.Name.Equals(item)));
            }
        }
    }
}
