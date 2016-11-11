/*
 * (c) Copyright 2009 The Tenece Professional Services.
 * 
 * ============================================================
 * Project Info:  http://tenece.com
 * Project Lead:  Amachree Jeffry (jeffry.amachree@tenece.com);
 * ============================================================
 *
 *
 * Licensed under the Tenece Professional Services;
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.tenece.com/
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 *
 * - Redistributions of source code must retain the above copyright
 *   notice, this list of conditions and the following disclaimer.
 *
 * - Redistribution in binary form must reproduce the above copyright
 *   notice, this list of conditions and the following disclaimer in
 *   the documentation and/or other materials provided with the
 *   distribution.
 *
 * Neither the name of Strategiex. or the names of
 * contributors may be used to endorse or promote products derived
 * from this software without specific prior written permission.
 *
 * This software is provided "as is," without a warranty of any
 * kind. All express or implied conditions, representations and
 * warranties, including any implied warranty of merchantability,
 * fitness for a particular purpose or non-infringement, are hereby
 * excluded. 
 * Tenece and its licensors shall not be liable for any damages
 * suffered by licensee as a result of using, modifying or
 * distributing the software or its derivatives. In no event will Strategiex
 * or its licensors be liable for any lost revenue, profit or data, or
 * for direct, indirect, special, consequential, incidental or
 * punitive damages, however caused and regardless of the theory of
 * liability, arising out of the use of or inability to use software,
 * even if Strategiex has been advised of the possibility of such damages.
 *
 * You acknowledge that Software is not designed, licensed or intended
 * for use in the design, construction, operation or maintenance of
 * any nuclear facility.
 */
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



/// <summary>
/// AuthenticationFilter
/// </summary>
public class AuthenticationFilter
{
	public AuthenticationFilter()
	{
		//do Nothing
	}
    /**
     * This method is to validate a user session 
     * Usage : AuthenticationFilter.validateSession(session, response)
     */
    public static void validateSession(System.Web.SessionState.HttpSessionState session, System.Web.HttpResponse response){
        //Get role and other relevant parameters
        string roleID = (string) session.Contents["role"];
        string uid = (string) session.Contents["userName"];
        //check if information is valid.
        if(roleID == null || roleID == ""){
            //if invalid, return to logout processor..
            response.Redirect("~/logout_processor.htm?err=x1", true);
        }
        
    }

    /**
     * This method is to validate a user session 
     * Usage : AuthenticationFilter.validateSession(session, response)
     */
  
    /**
     * This method is to validate a user session 
     * Usage : AuthenticationFilter.validateCourseRegSession(session, response)
     */
    public static void validateCourseRegSession(System.Web.SessionState.HttpSessionState session, System.Web.HttpResponse response)
    {
        Int32 ProgrammeId = (Int32)session.Contents["ProgrammeId"];
        Int32 LevelId = (Int32)session.Contents["LevelId"];
        Int32 SessionId = (Int32)session.Contents["SessionId"];
        Int32 PersonalId = (Int32)session.Contents["PersonalId"];
        if (ProgrammeId == 0 )
        {
            //if invalid, return to logout processor..
            response.Redirect("~/logout_processor.htm?err=x2", true);
        }
        if (LevelId == 0 )
        {
            //if invalid, return to logout processor..
            response.Redirect("~/logout_processor.htm?err=x2", true);
        }
        if (SessionId == 0)
        {
            //if invalid, return to logout processor..
           // response.Redirect("~/logout_processor.htm?err=x2", true);
        }
        if (PersonalId == 0)
        {
            //if invalid, return to logout processor..
            response.Redirect("~/logout_processor.htm?err=x2", true);
        }
    }
}
