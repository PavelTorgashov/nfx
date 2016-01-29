//WARNING: This code was auto generated by template compiler, do not modify by hand!
//Generated on 29.01.2016 20:59:56 by NFX.Templatization.TextCSTemplateCompiler at SAMSON

using System; 
using System.Text; 
using System.Linq; 
using System.Collections.Generic; 
using NFX.Wave.Templatization; 

namespace WaveTestSite.Pages 
{

 ///<summary>
 /// Master page for all pages on this site
 ///</summary>
 public abstract class Master : NFX.Wave.Templatization.WaveTemplate
 {

    public virtual string Title { get {return "NFX.WAVE Framework Demo"; } }

    public const string CONTENT_WIDTH = "90%";
   
    protected abstract void renderHeader();
    protected abstract void renderBody();
    protected virtual void renderFooter() { defaultFooter(); }

     protected override void DoRender()
     {
       base.DoRender();
        Target.Write( Master._63_S_LITERAL_0 );
        Target.Write( Master._63_S_LITERAL_1 );
        Target.Write(Target.Encode( Title ));
        Target.Write( Master._63_S_LITERAL_2 );
        Target.Write(Target.Encode( CONTENT_WIDTH ));
        Target.Write( Master._63_S_LITERAL_3 );
        Target.Write(Target.Encode( CONTENT_WIDTH ));
        Target.Write( Master._63_S_LITERAL_4 );
        Target.Write(Target.Encode( CONTENT_WIDTH ));
        Target.Write( Master._63_S_LITERAL_5 );
      renderHeader();
        Target.Write( Master._63_S_LITERAL_6 );
      renderBody();
        Target.Write( Master._63_S_LITERAL_7 );
      renderFooter();
        Target.Write( Master._63_S_LITERAL_8 );
        Target.Write(Target.Encode( DateTime.Now ));
        Target.Write( Master._63_S_LITERAL_9 );
        Target.Write(Target.Encode( Context.Request.RemoteEndPoint ));
        Target.Write( Master._63_S_LITERAL_10 );
      if(Context.GeoEntity!=null){
           var fn = (Context.GeoEntity.Location.CountryISOName ?? string.Empty).ToLower();
         
        Target.Write( Master._63_S_LITERAL_11 );
        Target.Write(Target.Encode( Context.GeoEntity.LocalityName ));
        Target.Write( Master._63_S_LITERAL_12 );
        Target.Write(Target.Encode( fn ));
        Target.Write( Master._63_S_LITERAL_13 );
      }
        Target.Write( Master._63_S_LITERAL_14 );

     }
    protected void defaultFooter()
    {
        Target.Write( Master._63_S_LITERAL_15 );

    }


     #region Literal blocks content
        private const string _63_S_LITERAL_0 = @"
"; 
        private const string _63_S_LITERAL_1 = @"   
<!DOCTYPE html>
<html>
 <head>   
   <title>"; 
        private const string _63_S_LITERAL_2 = @"</title>
   <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
   <meta name=""viewport"" content=""width=device-width, initial-scale=1.0, user-scalable=no"">


   <style>
       body 
       {
          font-family: Verdana, Sans-Serif;
          font-size: 9pt;
          width: auto;
          padding: 0px;
          border: none;
          background-color: white;
          margin: 0px;
          color: #7a7a7a;
          min-width: 500px;
       } 
        h1
        {
          font-size: 150%;
          color: White;   
          text-shadow: Black 1px 1px 4px;
          display: inline;
          margin-left: 110px;         
        }                              

        h2
        {
          font-size: 120%;
          text-shadow: Silver 1px 1px 3px;
        }

        h3
        {
          font-size: 100%;
          margin-bottom: -8px;
        } 

        hr
        {
          border: none;
          width: 100%;
          background-color: #b8b8b8;
          height: 1px;
        }

        a
        {
          outline: none;
        }

        :link
        {
          font-size: 9pt;
          color: #3560a4;     
          text-shadow:  Silver -1px -1px 1px;
          text-decoration: none;
        }

        :link:hover
        {
         position: relative;
         left: 0px;
         top:-1px;                        
         text-shadow: Yellow 1px 1px 16px;   
         color: #3560a4;
        }

        :visited
        {
          font-size: 9pt;
          text-decoration: none;
          color: #9a2497;
        }

        #divTopPanel
        {
          background-color: #f8433c;
          height: auto;
        }

        #divHeader
        {
         width: "; 
        private const string _63_S_LITERAL_3 = @";
         height: auto;
         background-color: #fba9a6;
         margin-left: auto;
         margin-right: auto;
         padding: 8pt; 
         background-image: url(""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGkAAAAjCAIAAAAYI7NnAAAAA3NCSVQICAjb4U/gAAAACXBIWXMAAAsSAAALEgHS3X78AAAAFnRFWHRDcmVhdGlvbiBUaW1lADAxLzI2LzA5nt1YzAAAABh0RVh0U29mdHdhcmUAQWRvYmUgRmlyZXdvcmtzT7MfTgAABBF0RVh0WE1MOmNvbS5hZG9iZS54bXAAPD94cGFja2V0IGJlZ2luPSIgICAiIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNC4xLWMwMzQgNDYuMjcyOTc2LCBTYXQgSmFuIDI3IDIwMDcgMjI6Mzc6MzcgICAgICAgICI+CiAgIDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+CiAgICAgIDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiCiAgICAgICAgICAgIHhtbG5zOnhhcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyI+CiAgICAgICAgIDx4YXA6Q3JlYXRvclRvb2w+QWRvYmUgRmlyZXdvcmtzIENTMzwveGFwOkNyZWF0b3JUb29sPgogICAgICAgICA8eGFwOkNyZWF0ZURhdGU+MjAwOS0wMS0yN1QwMzo1NDowOFo8L3hhcDpDcmVhdGVEYXRlPgogICAgICAgICA8eGFwOk1vZGlmeURhdGU+MjAwOS0wMS0yN1QwNDoxMjo1M1o8L3hhcDpNb2RpZnlEYXRlPgogICAgICA8L3JkZjpEZXNjcmlwdGlvbj4KICAgICAgPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIKICAgICAgICAgICAgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIj4KICAgICAgICAgPGRjOmZvcm1hdD5pbWFnZS9wbmc8L2RjOmZvcm1hdD4KICAgICAgPC9yZGY6RGVzY3JpcHRpb24+CiAgIDwvcmRmOlJERj4KPC94OnhtcG1ldGE+CiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgr0dVXQAAD89JREFUaN7tWml0XdV53efc+d0360lPsuRBkmc8YYwhzBiDAUPKkEIhCSRNScjKakoY2rAo6YKGNg0phSaQAmGlGRywiwmOBwhmMJjKsTGeFSNLyLJlWdJ7T28e7nTO6Q8NtjC4EitQ6OL80Lr33O+dde+++/vO/vYV4RuvwydykCD7wp2TV2+OAOyTeYcUn43PsPv4h/wpf/EEEIMpPnxw4jH7DLtRxTBgsF98t3v1GzSZNb5+Ve6ff+X7zrVOMCiKBdKb5tMbiVMWwSC57cd6a1ctwD9u7AgAhYCQoXMmBBMAiExACQAQAsaFK4hEIJP3X4ULEIKRixzC44SOjne5EOO7b0NjVy8tNteV1m9Vrr2cP72x74uXRSvlwrObMgTKxQsjWkTeubNXiABQN5qJHwt2XKA34Vi2RwgRAnVR1adLnIvEgFeyXACMiWhAjobVQoknczYgADIafWHqsuXCYwwAFyLkk6sjasXifX2OGARM8IaYoShkXE8nBPIpMnOSlspZXkp1PQouv/xW+a9+NMHxGuOR3huvyV95t9KTmg/wjwK4k2FHFHI04V54986ixVzbSueK37ii+bHb5tkl7/Pf39fVV+KelUplbrp02i/uW/zoqvYHVnYFDeI47ghNHce1rdKSxdO2HxighDDGB9L5s+bEXn/4vBWvJ+58ql2XvGKprMrY8MC5Z54SEO74MosLqKa0ZKFZKjsAigXvyotqDs1w664rceGHSPu0CBAC7I99nyWkbDkC1LadQrHIXWtNS8/hXotzXrZcEFIoFAHWl3Vgi3LFlWQ5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""); 
         background-repeat: no-repeat;
         background-position: left;
        }

        #divContentPanel
        {
          background-color: #f0f0f0;
          height: auto;
        }

        #divContent
        {
         width: "; 
        private const string _63_S_LITERAL_4 = @";
         height: auto;
         background-color: #f8f6e4;
         margin-left: auto;
         margin-right: auto;
         padding: 8pt;
        }

        #divBottomPanel
        {
          background-color: #f8433c;
          height: auto;
        }

        #divBottomContent
        {
         width: "; 
        private const string _63_S_LITERAL_5 = @";
         height: auto;
         background-color: #fba9a6;
         margin-left: auto;
         margin-right: auto;
         padding: 8pt;
        }

        .orangeStripe
        {
         width: 100%;
         height: 4px;
         background-color: #f3a832;
        }
              
        .tail
        {
           text-align: center;
           width: 100%;
        }

   </style>

 </head>
 <body>
   <div id=""divTopPanel"">
       <div id=""divHeader"">"; 
        private const string _63_S_LITERAL_6 = @"</div>
   </div>     
   
   <div id=""divContentPanel"">
       <div id=""divContent"">"; 
        private const string _63_S_LITERAL_7 = @"</div>
   </div>
   
   <div id=""divBottomPanel"">
       <div id=""divBottomContent"">
            "; 
        private const string _63_S_LITERAL_8 = @"
       </div>
   </div>
   <div class=""orangeStripe"" />
   <br />
     <div class=""tail"">
         &copy; 2003-2014&nbsp;&nbsp;IT Adapter Corporation / Aum Code
         <br /> 
         This site is served by the <strong>NFX.Wave</strong> framework
          <br />
         Generated on "; 
        private const string _63_S_LITERAL_9 = @"  for "; 
        private const string _63_S_LITERAL_10 = @"
         "; 
        private const string _63_S_LITERAL_11 = @"
         from "; 
        private const string _63_S_LITERAL_12 = @" <img src=""/stock/site/flags/"; 
        private const string _63_S_LITERAL_13 = @".png"">
         "; 
        private const string _63_S_LITERAL_14 = @"
     </div>
 </body>
</html> 

"; 
        private const string _63_S_LITERAL_15 = @"
 <a href=""http://blog.aumcode.com"" target=""_blank"">Aum Code Blog</a> |
 <a href=""http://itadapter.com"" target=""_blank"">IT Adapter Site</a> |
 <a href=""http://itadapter.com/nfxHelp"" target=""_blank"">NFX Help</a>
 &nbsp;"; 
     #endregion

 }//class
}//namespace
