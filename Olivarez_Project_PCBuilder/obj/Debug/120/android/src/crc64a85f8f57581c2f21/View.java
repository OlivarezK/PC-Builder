package crc64a85f8f57581c2f21;


public class View
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Olivarez_Project_PCBuilder.View, Olivarez_Project_PCBuilder", View.class, __md_methods);
	}


	public View ()
	{
		super ();
		if (getClass () == View.class)
			mono.android.TypeManager.Activate ("Olivarez_Project_PCBuilder.View, Olivarez_Project_PCBuilder", "", this, new java.lang.Object[] {  });
	}


	public View (int p0)
	{
		super (p0);
		if (getClass () == View.class)
			mono.android.TypeManager.Activate ("Olivarez_Project_PCBuilder.View, Olivarez_Project_PCBuilder", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
