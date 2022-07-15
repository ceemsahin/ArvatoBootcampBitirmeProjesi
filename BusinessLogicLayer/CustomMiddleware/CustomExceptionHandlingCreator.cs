using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBuddy.Middlewares.ExceptionHandling;
using TechBuddy.Middlewares.ExceptionHandling.Infrastructure;

namespace BusinessLogicLayer.CustomMiddleware
{
    public class CustomExceptionHandlingCreator : IResponseModelCreator
    {
        //Kullandığım custom middleware paketi ile yakalanacak hatalara karşı ne gönderileceğini burada tanımlıyorum.Aslında burası olmasa da direkt program.cs de tanımladıgım middleware ile de otomatik olarak yakalayabiliriz.Burası sadece Model ile de yapabiliriz demek için var.
        public object CreateModel(ModelCreatorContext model)
        {
            return new
            {
                StatusCode = model.HttpStatusCode,
                ExMessage = model.ErrorMessage,
                DetailExMessage = model.Exception.ToString()
                
            };
           
        }
    }

}
