using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobEducationRepository : IDataRepository<CompanyJobEducationPoco>
    {
        public void Add(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager
                                                            .ConnectionStrings["humberconnection"]
                                                            .ConnectionString
                                                            ))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobEducationPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Educations]
                        ([Id],
						[Job]
						,[Major]
						,[Importance]
						)
                    VALUES 
                        (@Id,@Job,@Major,@Importance)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@Importance", item.Importance);
               

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager
                                                           .ConnectionStrings["humberconnection"]
                                                           .ConnectionString
                                                           ))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT 
                                        [Id]
										
										,[Major]
										,[Importance]
									
										,[Time_Stamp]
                                    FROM [JOB_PORTAL_DB].[dbo].[Company_Job_Educations]";
                conn.Open();

                int x = 0;
                SqlDataReader rdr = cmd.ExecuteReader();
                CompanyJobEducationPoco[] appPocos = new CompanyJobEducationPoco[10000];

                while (rdr.Read())
                {
                    CompanyJobEducationPoco poco = new CompanyJobEducationPoco();
                    poco.Id = rdr.GetGuid(0);
                   
                    poco.Major = rdr.GetString(1);
                    poco.Importance = rdr.GetInt16(2);
                  
                    poco.TimeStamp = (byte[])rdr[3];

                    appPocos[x] = poco;
                    x++;
                }
                return appPocos.Where(a => a != null).ToList();
            }
        }

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager
                                                          .ConnectionStrings["humberconnection"]
                                                          .ConnectionString
                                                          ))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobEducationPoco item in items)
                {
                    cmd.CommandText = $"DELETE FROM Company_Job_Educations WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", item.Id);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager
                                                            .ConnectionStrings["humberconnection"]
                                                            .ConnectionString
                                                            ))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobEducationPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Job_Educations]
                        SET ([Job] = @Job,
                        [Major] = @Major,
                        [Importance] = @Importance,
                       )
                    WHERE 
                        [Id] = @Id";


                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@Importance", item.Importance);


                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
