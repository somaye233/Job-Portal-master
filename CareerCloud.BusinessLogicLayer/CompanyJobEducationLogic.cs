using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
	{
		public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
		{

		}
		public override void Add(CompanyJobEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
		public override void Update(CompanyJobEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
		protected override void Verify(CompanyJobEducationPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();


			foreach (var poco in pocos)
			{
				if (String.IsNullOrEmpty(poco.Major) || poco.Major.Length < 3)
				{
					exceptions.Add(new ValidationException(200, $"Major for CompanyJobEducation {poco.Id} must be at least 2 characters."));
				}
				if (poco.Importance < 0)
				{
					exceptions.Add(new ValidationException(201, $"Importance for CompanyJobEducation {poco.Id} must be at least 10 characters."));
				}

			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
