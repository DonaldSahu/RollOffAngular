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
        public async Task<FormTable> AddFormAsync(FormTable form)
        {
            await context.FormTables.AddAsync(form);
            await context.SaveChangesAsync();
            return form;
        }

        public async Task<FormTable> DeleteForm(double ggid)
        {
            var formDetails = await context.FormTables.FirstOrDefaultAsync(x => x.GlobalGroupId == ggid);
            context.FormTables.Remove(formDetails);
            await context.SaveChangesAsync();
            return formDetails;
        }

        public async Task<IEnumerable<FormTable>> GetDetailsAsync()
        {
            return await context.FormTables.ToListAsync();
        }

        public async Task<FormTable> GetDetailsGGID(double ggid)
        {
            var formdetails = await context.FormTables.FirstOrDefaultAsync(x => x.GlobalGroupId == ggid);
            return formdetails;
        }

        public async Task<FormTable> UpdateForm(double ggid, FormTable form)
        {
            var existingemployee = await context.FormTables.FirstOrDefaultAsync(x => x.GlobalGroupId == ggid);
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
            existingemployee.Practise = form.Practise;
            existingemployee.RollOffEndDate = form.RollOffEndDate;
            existingemployee.ReasonForRollOff = form.ReasonForRollOff;
            existingemployee.ThisReleaseNeedBackfillIsBackfilled = form.ThisReleaseNeedBackfillIsBackfilled;
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

            await context.SaveChangesAsync();
            return existingemployee;
        }
    }
}
