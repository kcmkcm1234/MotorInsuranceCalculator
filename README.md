# MotorInsuranceCalculator
Insurance premium calculation WPF application. Allows user to enter policy details, add drivers and claims, and calculate the premium based on this data

Users can change the start date of the policy via a date picker
Users can add drivers/claims by entering data in the relevant input fields and clicking "Add Driver" or "Add Claim"
Users can remove drivers/claims by selecting the desired item in the listview and clicking "Remove Driver" or "Remove Claim"
Users can calculate the policy premium by clicking on "Evaluate"

Views:
PolicyView - displays policy data such as start date, drivers, claims and premium. Includes buttons to add/remove drivers and claims, and to calculate premium

ViewModels:
PolicyViewModel - binds policy data to view. Handles operations for adding/removing data and calculating premium

Models:
Policy - start date, drivers, premium
Driver - name, date of birth, occupation, claims
Claim - date
Occupation - job title, job enum
