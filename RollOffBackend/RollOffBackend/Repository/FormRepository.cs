using Microsoft.EntityFrameworkCore;
using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public class FormRepository : IFormRepository
    {
        private readonly Roll_offContext context;
        public FormRepository(Roll_offContext context)
        {
            this.context = context;
        }
        public async Task<RolloffForm> AddFormAsync(RolloffForm form)
        { 
            await context.RolloffForms.AddAsync(form);
            await context.SaveChangesAsync();
            return form;
        }

        public async Task<RolloffForm> DeleteForm(double ggid)
        {
            var formDetails = await context.RolloffForms.FirstOrDefaultAsync(x => x.GlobalGroupId == ggid);
            context.RolloffForms.Remove(formDetails);
            await context.SaveChangesAsync();
            return formDetails;
        }

        public async Task<IEnumerable<RolloffForm>> GetDetailsAsync()
        {
            return await context.RolloffForms.ToListAsync();
        }

        public async Task<RolloffForm> GetDetailsGGID(double ggid)
        {
            var formdetails = await context.RolloffForms.FirstOrDefaultAsync(x => x.GlobalGroupId == ggid);
            return formdetails;
        }

        public async Task<RolloffForm> UpdateForm(double ggid, RolloffForm form)
        {
            var existingemployee = await context.RolloffForms.FirstOrDefaultAsync(x => x.GlobalGroupId == ggid);
            if(existingemployee == null)
            {
                return null;
            }
            existingemployee.EmployeeNo = form.EmployeeNo;
            existingemployee.Name = form.Name;
            existingemployee.PrimarySkill = form.PrimarySkill;
            existingemployee.LocalGrade = form.LocalGrade;
            existingemployee.ProjectCode = form.ProjectCode;
            existingemployee.ProjectName = form.ProjectName;
            existingemployee.Practice = form.Practice;
            existingemployee.RollOffEndDate = form.RollOffEndDate;
            existingemployee.ReasonForRollOff = form.ReasonForRollOff;
            existingemployee.ThisReleaseNeedBackfillIsBackFilled = form.ThisReleaseNeedBackfillIsBackFilled;
            existingemployee.PerformanceIssue = form.PerformanceIssue;
            existingemployee.Resigned = form.Resigned;
            existingemployee.UnderProbation = form.UnderProbation;
            existingemployee.LongLeave = form.LongLeave;
            existingemployee.TechnicalSkills = form.TechnicalSkills;
            existingemployee.Communication = form.Communication;
            existingemployee.RoleCompetencies = form.RoleCompetencies;
            existingemployee.Remarks = form.Remarks;
            existingemployee.RelevantExperienceYrs = form.RelevantExperienceYrs;
            existingemployee.Status = form.Status;
            existingemployee.RequestDate = form.RequestDate;
            existingemployee.RollOffStartDate = form.RollOffEndDate;
            existingemployee.OtherReasons = form.OtherReasons;
            existingemployee.Labour = form.Labour;

            await context.SaveChangesAsync();
            return existingemployee;
        }
    }
}
