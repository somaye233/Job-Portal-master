using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
	{
		public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
		{

		}
		public override void Add(CompanyProfilePoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
		public override void Update(CompanyProfilePoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
		protected override void Verify(CompanyProfilePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();


			foreach (var poco in pocos)
			{
				
			   if (string.IsNullOrEmpty(poco.CompanyWebsite) ||(!poco.CompanyWebsite.EndsWith(".ca") && !poco.CompanyWebsite.EndsWith(".com") && !poco.CompanyWebsite.EndsWith(".biz")))
			   {
					exceptions.Add(new ValidationException(600, $"CompanyWebsite for CompanyProfile {poco.Id} must end with the following extensions – .ca, .com, .biz"));
			   }
				if (string.IsNullOrEmpty(poco.ContactPhone) || !Regex.Match(poco.ContactPhone, @"^(\+[0-9]{9})$").Success)
				{
					exceptions.Add(new ValidationException(601, $"PhoneNumber for CompanyProfile {poco.Id} should be valid"));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
