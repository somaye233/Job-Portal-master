using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobSkillLogic : BaseLogic<CompanyJobSkillPoco>
	{
		public CompanyJobSkillLogic(IDataRepository<CompanyJobSkillPoco> repository) : base(repository)
		{

		}
		public override void Add(CompanyJobSkillPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
		public override void Update(CompanyJobSkillPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
		protected override void Verify(CompanyJobSkillPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();


			foreach (var poco in pocos)
			{
				if (poco.Importance < 10)
				{
					exceptions.Add(new ValidationException(400, $"Importance for CompanyJobSkill {poco.Id} must be at least 10 characters."));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
