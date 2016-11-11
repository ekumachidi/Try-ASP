using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Notifications
/// </summary>
public class PortalNotification
{
    public DateTime PubDate { get; set; }
    public bool IsActive { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
	public PortalNotification()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}