using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDigitalToolbox
{
    public class TODO
    {
        //I believe that TODO's that are stored in CSHTML files aren't viewable in the Task List, so instead I'll store them, and any other homeless tasks here...

        /*  TODO 40 Views>Shared>Layout.cshtml: Style
        *       Add custom style sheet, rather than using the blue and white default of ASP.NET MVC Core
        *   TODO 20 Views>Shared>Layout.cshtml: Navbar
        *       Fix the janky-ness of the navbar layout
        *   TODO 10 Add related entities
        *       Include Users and Comments within the Embedded Tool views, so that users can comment, and that when a user adds a tool, they are associated with the 'uploader' field
        *       
        *   TODO 30 Host Site 
        *   TODO 41 Optimize Site
        *   TODO 42 Fully Async Site
        */

        /* Changes to Scaffolding: (Using Embeddeds as guinea pig)
         *  The following changes must be added to all domain models (excluding embeddeds)
         *      
         *      Update Index view: 
         *          -   Add slugs for the following actions:
         *              -   edit
         *              -   details
         *              -   delete 
         *          -   Delete all fields, excluding Title & Description
         *          -   Split actions into their own columns
         *          -   Added "table-striped table-dark" to class of table element
         *          -   Added "text-nowrap" class to description field
         *          
         *      Update Create view:
         *          -   Delete H4
         *          -   Update H1 from "Create" to "<tool type> - Create"
         *      
         *  
         *      Update Details view:
         *         -    Add slug to edit action
         *         -    Change header from "Details" to "@Model.Title - Details"
         *         -    Delete div>H4
         *      
         *      Update Edit view:
         *         -    Delete H4
         *         -    Change H1 from "Edit" to "@Model.Title - Edit"
         *         
         *      Update Delete View
         *          -   Update H3 from "this?" to ""@Model.Title"?"
         *          -   Delete div>H4
         *      TODO: Update Guide Scaffold from Embedded scaffold changes
         *      TODO: Update Helpful Links Scaffold from Embedded scaffold changes
         *      TODO: Update Macros Scaffold from Embedded scaffold changes
         *      TODO: Update Program Scaffold from Embedded scaffold changes
         */
    }
}
