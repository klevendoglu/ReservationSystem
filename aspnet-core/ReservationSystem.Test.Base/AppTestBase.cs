using Abp;
using Abp.Events.Bus;
using Abp.Events.Bus.Entities;
using Abp.Modules;
using Abp.TestBase;
using ReservationSystem.EntityFrameworkCore;
using ReservationSystem.Test.Base.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Test.Base
{
    public abstract class AppTestBase<T> : AbpIntegratedTestBase<T> where T : AbpModule
    {
        protected AppTestBase()
        {
            SeedTestData();
            LoginAsDefaultTenantAdmin();
        }

        private void SeedTestData()
        {
            void NormalizeDbContext(ReservationSystemDbContext context)
            {
                
            }

            //Seed initial data for default tenant
            AbpSession.TenantId = 1;

            UsingDbContext(context =>
            {
                NormalizeDbContext(context);
                new TestDataBuilder(context, 1).Create();
            });
        }

        protected IDisposable UsingTenantId(int? tenantId)
        {
            var previousTenantId = AbpSession.TenantId;
            AbpSession.TenantId = tenantId;
            return new DisposeAction(() => AbpSession.TenantId = previousTenantId);
        }

        protected void UsingDbContext(Action<ReservationSystemDbContext> action)
        {
            UsingDbContext(AbpSession.TenantId, action);
        }

        protected Task UsingDbContextAsync(Func<ReservationSystemDbContext, Task> action)
        {
            return UsingDbContextAsync(AbpSession.TenantId, action);
        }

        protected TResult UsingDbContext<TResult>(Func<ReservationSystemDbContext, TResult> func)
        {
            return UsingDbContext(AbpSession.TenantId, func);
        }

        protected Task<TResult> UsingDbContextAsync<TResult>(Func<ReservationSystemDbContext, Task<TResult>> func)
        {
            return UsingDbContextAsync(AbpSession.TenantId, func);
        }

        protected void UsingDbContext(int? tenantId, Action<ReservationSystemDbContext> action)
        {
            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<ReservationSystemDbContext>())
                {
                    action(context);
                    context.SaveChanges();
                }
            }
        }

        protected async Task UsingDbContextAsync(int? tenantId, Func<ReservationSystemDbContext, Task> action)
        {
            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<ReservationSystemDbContext>())
                {
                    await action(context);
                    await context.SaveChangesAsync();
                }
            }
        }

        protected TResult UsingDbContext<TResult>(int? tenantId, Func<ReservationSystemDbContext, TResult> func)
        {
            TResult result;

            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<ReservationSystemDbContext>())
                {
                    result = func(context);
                    context.SaveChanges();
                }
            }

            return result;
        }

        protected async Task<TResult> UsingDbContextAsync<TResult>(int? tenantId, Func<ReservationSystemDbContext, Task<TResult>> func)
        {
            TResult result;

            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<ReservationSystemDbContext>())
                {
                    result = await func(context);
                    await context.SaveChangesAsync();
                }
            }

            return result;
        }

        #region Login

        protected void LoginAsHostAdmin()
        {
            //LoginAsHost(AbpUserBase.AdminUserName);
        }

        protected void LoginAsDefaultTenantAdmin()
        {
            //LoginAsTenant(AbpTenantBase.DefaultTenantName, AbpUserBase.AdminUserName);
        }

        protected void LoginAsHost(string userName)
        {
            //AbpSession.TenantId = null;

            //var user = UsingDbContext(context => context.Users.FirstOrDefault(u => u.TenantId == AbpSession.TenantId && u.UserName == userName));
            //if (user == null)
            //{
            //    throw new Exception("There is no user: " + userName + " for host.");
            //}

            //AbpSession.UserId = user.Id;
        }

        protected void LoginAsTenant(string tenancyName, string userName)
        {
            AbpSession.TenantId = null;

            var tenant = UsingDbContext(context => context.CurrentTenant);
            if (tenant == null)
            {
                throw new Exception("There is no tenant: " + tenancyName);
            }

            var user = UsingDbContext(context => context.Users.FirstOrDefault(u => u.TenantId == tenant.Id && u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for tenant: " + tenancyName);
            }

            //AbpSession.UserId = user.Id;
        }

        #endregion

    }
}
