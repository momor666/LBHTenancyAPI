using LBH.Data.Domain;

namespace LBHTenancyAPI.UseCases.Contacts.Models
{
    public class TenancySearch
    {
        public TenancySearch()
        {

        }

        public TenancySearch(TenancySummary tenancySummary)
        {
            FirstName = tenancySummary.FirstName;
            LastName = tenancySummary.LastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
