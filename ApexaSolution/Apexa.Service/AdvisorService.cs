﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Service;
using Apexa.Data.Dto;
using Apexa.IDAL;
using Apexa.IService;
using Apexa.Data;
using Apexa.Data.Parameters;
using Apexa.IService.Helper;
using Apexa.Service.Helper;

namespace Apexa.Service
{
    public class AdvisorService : BaseService, IAdvisorService
    {
        private readonly IAdvisorDal _advisorDal;
        private readonly IValidator _validator;
        private readonly IUtil _utilService;
        private readonly string _maskChar = "*";
        private readonly int _unMaskLength = 3;
        public AdvisorService(IAdvisorDal advisorDal,IValidator validator,IUtil util)
        {
            _advisorDal = advisorDal;
            _validator = validator;
            _utilService = util;
        }
        /// <summary>
        /// Get advisor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApexaResult GetAdvisor(long id)
        {
            var advisor = _advisorDal.Get(id);
            MaskAdvisor(advisor);
            return new ApexaResult(advisor);
        }
        /// <summary>
        /// search advisors
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public ApexaResult GetAdvisorList(QueryParameter? parameter)
        {
            var advisorList = _advisorDal.GetAdvisors(parameter);
            foreach (var advisor in advisorList)
            {
                MaskAdvisor(advisor);
            }
            return new ApexaResult(advisorList);
        }

        /// <summary>
        /// add new advisor
        /// </summary>
        /// <param name="advisor"></param>
        /// <returns></returns>
        public ApexaResult AddAdvisor(Advisor advisor)
        {
            if (_validator.IsValidate(advisor, out IList<ValidationResult>  validationResults, true))
            {
                advisor.Id = null;//set id to null to enable auto id generation
                advisor.Status = _utilService.NexHealthStatus();
                return new ApexaResult(_advisorDal.Add(advisor));
            }
            else
            {
                return new ApexaResult(false, null, validationResults);
            }

        }
        /// <summary>
        /// Update advisor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="advisor"></param>
        /// <returns></returns>
        public ApexaResult UpdateAdvisor(long id, Advisor advisor)
        {
            if (_validator.IsValidate(advisor, out IList<ValidationResult> validationResults, false))
            {
                _advisorDal.Update(id, advisor);
                return new ApexaResult(null);
            }
            else
            {
                return new ApexaResult(false, null, validationResults);
            }
        }
        /// <summary>
        /// Delete advisor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApexaResult DeleteAdvisor(long id)
        {

            if (_validator.IsExist(id, out IList<ValidationResult> validationResults))
            {
                _advisorDal.Delete(id);
                return new ApexaResult(null);
            }
            else
            {
                return new ApexaResult(false, null, validationResults);
            }

        }
        /// <summary>
        /// Mask advisor fields
        /// </summary>
        /// <param name="advisor"></param>
        private void MaskAdvisor(Advisor? advisor)
        {
            if (advisor != null)
            {
                if (!string.IsNullOrEmpty(advisor.Sin))
                {
                    advisor.Sin = advisor.Sin.Mask(_maskChar, _unMaskLength);
                }
                if (!string.IsNullOrEmpty(advisor.PhoneNumber))
                {
                    advisor.PhoneNumber = advisor.PhoneNumber.Mask(_maskChar, _unMaskLength);
                }
            }
        }


    }
}
