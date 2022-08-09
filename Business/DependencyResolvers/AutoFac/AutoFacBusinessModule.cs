using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<BrandManager>().As<IBrandService>();
           builder.RegisterType<EfBrandDal>().As<IBrandDal>();

           builder.RegisterType<CategoryManager>().As<ICategoryService>();
           builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

           builder.RegisterType<ColourManager>().As<IColourService>();
           builder.RegisterType<EfColourDal>().As<IColourDal>();

           builder.RegisterType<CommentManager>().As<ICommentService>();
           builder.RegisterType<EfCommentDal>().As<ICommentDal>();

           builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
           builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

           builder.RegisterType<OrderManager>().As<IOrderService>();
           builder.RegisterType<EfOrderDal>().As<IOrderDal>();

           builder.RegisterType<ProductManager>().As<IProductService>();
           builder.RegisterType<EfProductDal>().As<IProductDal>();

           builder.RegisterType<SizeManager>().As<ISizeService>();
           builder.RegisterType<EfSizeDal>().As<ISizeDal>();

           builder.RegisterType<UserManager>().As<IUserService>();
           builder.RegisterType<EfUserDal>().As<IUserDal>();

           builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
           builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

           builder.RegisterType<SaleManager>().As<ISaleService>();
           builder.RegisterType<EfSaleDal>().As<ISaleDal>();

           builder.RegisterType<AuthManager>().As<IAuthService>();
           builder.RegisterType<JwtHelper>().As<ITokenHelper>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
