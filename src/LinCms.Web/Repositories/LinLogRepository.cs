﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FreeSql;
using LinCms.Web.Areas.Cms.Models.Logs;
using LinCms.Web.Data;
using LinCms.Web.Data.Extensions;
using LinCms.Web.Domain;

namespace LinCms.Web.Repositories
{
    public class LinLogRepository : BaseRepository<LinLog>
    {

        public LinLogRepository(IFreeSql fsql, Expression<Func<LinLog, bool>> filter = null, Func<string, string> asTable = null) : base(fsql, filter, asTable)
        {
        }

        public PagedResultDto<LinLog> GetLogUsers(LogSearchDto searchDto)
        {
            List<LinLog> linLogs = Select
                .WhereIf(!string.IsNullOrEmpty(searchDto.Keyword), r => r.Message.Contains(searchDto.Keyword))
                .WhereIf(!string.IsNullOrEmpty(searchDto.Name), r => r.UserName.Contains(searchDto.Name))
                .WhereIf(searchDto.Start.HasValue, r => r.Time >= searchDto.Start.Value)
                .WhereIf(searchDto.End.HasValue, r => r.Time <= searchDto.End.Value)
                .ToPagerList(searchDto, out long totalCount);

            return new PagedResultDto<LinLog>(totalCount, linLogs);

        }

        public PagedResultDto<LinLog> GetLoggedUsers(PageDto searchDto)
        {
            List<LinLog> linLogs = Select
                .ToPagerList(searchDto, out long totalCount);

            return new PagedResultDto<LinLog>(totalCount, linLogs);
        }
    }
}