using System.Collections;
using System.Collections.Generic;

public interface ISightInteraction
{

	void OnSightStart ();

	void OnSightStay ();

	void OnSightEnd ();
}
