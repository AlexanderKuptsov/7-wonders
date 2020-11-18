using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result
{
    public string status { get; set; }
    public string module { get; set; }
    public string type { get; set; }
    public string error_message { get; set; }

    public bool IsCorrect => (status == "SUCCESS" || status == "" || status == null);
}
