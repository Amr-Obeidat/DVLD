using DVLD_Business.Applications;
using System.Data;

namespace DVLD_Tests_;

[TestClass]
public class ApplicationsTest
{
    [TestMethod]
    public void Test1_FindApplications()
    {

        clsApplication application = new clsApplication();

        application = clsApplication.Find(43);
        Assert.IsNotNull(application,application.clsApplicationDTO.LastValidationError);

        Console.WriteLine("Application with the application id ="+application.clsApplicationDTO.ApplicationID+"Was found");
        Console.WriteLine(application.clsApplicationDTO.ApplicationStatus);
        string applicationtatues;

        switch(application.clsApplicationDTO.ApplicationStatus)
        {
            case 1:
                applicationtatues = "New";
                break;
            case 2:
                applicationtatues = "Cancelled";
                break;
            case 3:
                applicationtatues = "Completed";
                break;
          
            default:
                applicationtatues = "Unknown";
                break;
        }
        Console.WriteLine(applicationtatues);
    }
    [TestMethod]
    public void Test2_UpdateApplicationStatus()
    {

        clsApplication application = new clsApplication();
        application = clsApplication.Find(43);
        string applicationtatues;

        switch (application.clsApplicationDTO.ApplicationStatus)
        {
            case 1:
                applicationtatues = "New";
                break;
            case 2:
                applicationtatues = "Cancelled";
                break;
            case 3:
                applicationtatues = "Completed";
                break;

            default:
                applicationtatues = "Unknown";
                break;
        }

        Console.WriteLine("application Statues before the update is " + applicationtatues);
        application.clsApplicationDTO.ApplicationStatus = 3;
        application.Save();

        switch (application.clsApplicationDTO.ApplicationStatus)
        {
            case 1:
                applicationtatues = "New";
                break;
            case 2:
                applicationtatues = "Cancelled";
                break;
            case 3:
                applicationtatues = "Completed";
                break;

            default:
                applicationtatues = "Unknown";
                break;
        }

        Console.WriteLine("application Statues after the update is " + applicationtatues);



    }

    [TestMethod]
    public void Test3_DeleteApplicationStatus()
    {

        clsApplication application = new clsApplication();  
        application = clsApplication.Find(43);  
      bool success = clsApplication.Delete(application.clsApplicationDTO.ApplicationID);    
      Assert.IsTrue(success, "Failed to delete application."+application.clsApplicationDTO.LastValidationError);
        Console.WriteLine("The application with the application id ="+application.clsApplicationDTO.ApplicationID+" was deleted successfully.");



    }
    [TestMethod]
     public void Test4_GetAllApplications()
    {
        var dt = clsApplication.GetAllApplications();   

        Assert.IsNotNull(dt, "Failed to get all applications.");

        foreach (DataRow  row in dt.Rows)
        {
            Console.WriteLine("Application ID: " + row["ApplicationID"] + ", Status: " + row["ApplicationStatus"] + ", Last Status Date: " + row["LastStatusDate"]);
        }
    }
}
