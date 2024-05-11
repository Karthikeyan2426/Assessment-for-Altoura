using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public InputField UsernameField;
    public InputField PasswordField;

    // Preset credentials for the login
    private string correctUsername = "admin";
    private string correctPassword = "password";

    // Function to be called when the SubmitButton is clicked
    public void CheckLogin()
    {
        //Code to get the text entered in each field
        string usernameInput = UsernameField.text;
        string passwordInput = PasswordField.text;

        // Check if the entered username and password match the preset credentials
        if (usernameInput == correctUsername && passwordInput == correctPassword)
        {
            // If the credentials match, login successful display
            Debug.Log("Login Successful");

            // Logging in directs to the HomePage
            SceneManager.LoadScene("HomePage");
        }
        else
        {
            // If the credentials don't match, indicate failed login
            Debug.Log("Login Failed");
        }
    }

}
