using Dapper;
using JobOpenings.Data.Models;
using JobOpenins.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JobOpenins.Data.Repositories
{
    public class JobOpeningsRepository : IJobOpenings
    {
        public async Task<bool> InsertJobs(JobModel lstJobs)
        {

            //string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection("Data Source=#;Initial Catalog=#;User ID=#;Password=#");
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            SqlCommand sqlcomm = new SqlCommand("dbo.USP_INS_UPD_JOBS");
            sqlconn.Open();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.Parameters.AddWithValue("@Id", 0);
            sqlcomm.Parameters.AddWithValue("@Title", lstJobs.Title);
            sqlcomm.Parameters.AddWithValue("@Description", lstJobs.Description);
            sqlcomm.Parameters.AddWithValue("@LocationId", lstJobs.LocationId);
            sqlcomm.Parameters.AddWithValue("@DepartmentId", lstJobs.DepartmentId);
            sqlcomm.Parameters.AddWithValue("@ClosingDate", lstJobs.ClosingDate);

            //sqlcomm.ExecuteNonQuery();
            SqlDataReader sdr = sqlcomm.ExecuteReader();

            if (sdr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateJobs(JobModel lstJobs, int id)
        {
            SqlConnection sqlconn = new SqlConnection("Data Source=#;Initial Catalog=#;User ID=#;Password=#");
            SqlCommand sqlcomm = new SqlCommand("dbo.USP_INS_UPD_JOBS");
            sqlconn.Open();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.Parameters.AddWithValue("@Id", id);
            sqlcomm.Parameters.AddWithValue("@Title", lstJobs.Title);
            sqlcomm.Parameters.AddWithValue("@Description", lstJobs.Description);
            sqlcomm.Parameters.AddWithValue("@LocationId", lstJobs.LocationId);
            sqlcomm.Parameters.AddWithValue("@DepartmentId", lstJobs.DepartmentId);
            sqlcomm.Parameters.AddWithValue("@ClosingDate", lstJobs.ClosingDate);

            //sqlcomm.ExecuteNonQuery();
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<JobDtlModel>> GetJobList(SendJobModel lstJobs)
        {
            SqlConnection sqlconn = new SqlConnection("Data Source=#;Initial Catalog=#;User ID=#;Password=#");
            SqlCommand sqlcomm = new SqlCommand("dbo.USP_GET_JOB_LIST");
            sqlconn.Open();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            //sqlcomm.Parameters.AddWithValue("@Id", 0);
            
            sqlcomm.Parameters.AddWithValue("@LocationId", lstJobs.LocationId);
            sqlcomm.Parameters.AddWithValue("@DepartmentId", lstJobs.DepartmentId);

            //sqlcomm.ExecuteNonQuery();
            SqlDataReader sdr = sqlcomm.ExecuteReader();

            List<JobDtlModel> lstJobDtls = new List<JobDtlModel>();
            JobDtlModel JobDtls = new JobDtlModel();

            while (sdr.Read())
            {
                JobDtls.Job_Id = sdr["JOB_ID"].ToString();
                JobDtls.Code = sdr["CODE"].ToString();
                JobDtls.Title = sdr["TITLE"].ToString();
                JobDtls.Location = sdr["LOCATION"].ToString();
                JobDtls.Department = sdr["DEPARTMENT"].ToString();
                JobDtls.PostedDate = sdr["POSTEDDATE"].ToString();
                JobDtls.ClosingDate = sdr["CLOSINGDATE"].ToString();
                lstJobDtls.Add(JobDtls);
            }

            return lstJobDtls;
           

        }

        public async Task<List<GetJobDtlModel>> GetJobDetails(int id)
        {
            SqlConnection sqlconn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JobOpeningDB;User ID=#;Password=#");
            SqlCommand sqlcomm = new SqlCommand("dbo.USP_GET_JOB_DTLS");
            sqlconn.Open();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.Parameters.AddWithValue("@JobId", id);
            
            SqlDataReader sdr = sqlcomm.ExecuteReader();

            List<GetJobDtlModel> lstJobDtls = new List<GetJobDtlModel>();
            GetJobDtlModel JobDtls = new GetJobDtlModel();

            while (sdr.Read())
            {
                JobDtls.Job_Id = sdr["JOB_ID"].ToString();
                JobDtls.Code = sdr["CODE"].ToString();
                JobDtls.Title = sdr["TITLE"].ToString();
                JobDtls.PostedDate = sdr["POSTEDDATE"].ToString();
                JobDtls.ClosingDate = sdr["CLOSINGDATE"].ToString();
                lstJobDtls.Add(JobDtls);
            }

            return lstJobDtls;
        }
    }
}
