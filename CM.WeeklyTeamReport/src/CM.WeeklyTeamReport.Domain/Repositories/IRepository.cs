using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CM.WeeklyTeamReport.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Create(TEntity entity);

        TEntity Read(int entityId);

        void Update(TEntity entity);

        void Delete(int entityId);

        List<TEntity> ReadAll();

        List<TEntity> ReadAllByParentId(int entityId);
    }
}
