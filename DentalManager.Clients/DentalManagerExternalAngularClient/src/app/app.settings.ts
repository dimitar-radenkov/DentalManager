export class AppSettings {


   public static AUTH_KEY = "auth_token"; 

   private static API_ENDPOINT='https://localhost:44391/api/';

   public static LOGIN_ENDPOINT = AppSettings.API_ENDPOINT + "authorization/login";

   public static ALL_PATIENTS_ENDPOINT = AppSettings.API_ENDPOINT + "patients";
   public static GET_PATIENT_ENDPOINT = AppSettings.API_ENDPOINT + "patients";
   public static ADD_PATIENT_ENDPOINT = AppSettings.API_ENDPOINT + "patients/add";
   public static EDIT_PATIENT_ENDPOINT = AppSettings.API_ENDPOINT + "patients/edit";
   public static DELETE_PATIENT_ENDPOINT = AppSettings.API_ENDPOINT + "patients/delete";
}