using System;
using System.IO;
using Microsoft.Deployment.WindowsInstaller;

namespace MyWixCustomAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult MySimpleAction(Session session)
        {
            session.Log("Begin MySimpleAction");

            try
            {
                File.AppendAllText(@"c:\test\time.txt", ";Installation: " + DateTime.Now);
            }
            catch (Exception)
            {
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult MySimpleActionWithParams(Session session)
        {
            try
            {
                session.Message(InstallMessage.Warning,
                    new Record($"INSTALLLOCATION{session.CustomActionData["INSTALLLOCATION"]}"));

                session.Message(InstallMessage.Warning,
                    new Record($"Another Value{session.CustomActionData["AnotherValue"]}"));
            }
            catch (Exception exception)
            {
                session.Log(exception.ToString());
                return ActionResult.Failure;
            }
            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult ConfigureHostServer(Session session)
        {
            try
            {
                session.Message(InstallMessage.Warning,
                    new Record($"SERVER IP: {session.CustomActionData["SERVERIP"]}"));

                session.Message(InstallMessage.Warning,
                    new Record($"PORT NO: {session.CustomActionData["PORTNO"]}"));

                session.Message(InstallMessage.Warning,
                    new Record($"IS SKIPPED: {session.CustomActionData["SKIPPED"]}"));
            }
            catch (Exception exception)
            {
                session.Log(exception.ToString());
                return ActionResult.Failure;
            }
            return ActionResult.Success;
        }
    }
}