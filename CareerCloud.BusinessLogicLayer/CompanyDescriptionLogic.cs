using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
	{
		public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
		{

		}
		public override void Add(CompanyDescriptionPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
		public override void Update(CompanyDescriptionPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
		protected override void Verify(CompanyDescriptionPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();


			foreach (var poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.CompanyDescription) || poco.CompanyDescription.Length < 3)
				{
					exceptions.Add(new ValidationException(107, $"CompanyDescription for CompanyDescription {poco.Id} must be greater than 2 characters"));
				}
				if (string.IsNullOrEmpty(poco.CompanyName) || poco.CompanyName.Length < 3)
				{
					exceptions.Add(new ValidationException(106, $"CompanyDescription for CompanyName {poco.Id} must be greater than 2 characters"));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
