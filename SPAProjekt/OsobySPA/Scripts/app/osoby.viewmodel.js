function OsobyViewModel(app, dataModel) {

}

// Registrace ViewModelu
app.addViewModel({
    name: "Osoby",
    bindingMemberName: "osoby",
    factory: OsobyViewModel
});

//Jako první si vytvoříme "třídu" OsobyViewModel.Tu následně registrujeme jako ViewModel SPA aplikace pomocí objektu app, 
//který nám poskytuje a předgenerovalo ASP.NET.
//Důležité je zejména bindingMemberName, pomocí kterého budeme z šablon k ViewModelu přistupovat.