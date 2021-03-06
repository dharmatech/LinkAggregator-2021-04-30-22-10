open System
open canopy.runner.classic
open canopy.configuration
open canopy.classic

canopy.configuration.chromeDir <- System.AppContext.BaseDirectory

start chrome

"add user linus" &&& fun _ ->

    url "http://localhost:5000/Identity/Account/Register"

    "#Input_UserName"           << "linus"

    "#Input_Email"              << "linus@linux.org"

    "#Input_Password"           << "Secret123!"

    "#Input_ConfirmPassword"    << "Secret123!"
    
    click "/html/body/div/main/div/div[1]/form/button"

    click "Click here to confirm your account"

    sleep 3

"add user guy" &&& fun _ ->

    url "http://localhost:5000/Identity/Account/Register"

    sleep 3

    "#Input_UserName"           << "guy"

    "#Input_Email"              << "guy@symbolics.com"

    "#Input_Password"           << "Secret123!"

    "#Input_ConfirmPassword"    << "Secret123!"

    click "/html/body/div/main/div/div[1]/form/button"

    click "Click here to confirm your account"

"login linus" &&& fun _ ->

    url "http://localhost:5000/Identity/Account/Login"

    "#Input_UserName"   << "linus"

    "#Input_Password"   << "Secret123!"

    click "Log in"

    sleep 3

"create link linux" &&& fun _ ->

    url "http://localhost:5000/Links/Create"

    "#Link_Title" << "Linux"

    "#Link_Url" << "https://www.linux.org"

    click "Create"

    "/html/body/div/main/table/tbody/tr/td[2]/a" == "Linux"

"login guy" &&& fun _ ->

    url "http://localhost:5000/Identity/Account/Login"

    "#Input_UserName"   << "guy"

    "#Input_Password"   << "Secret123!"

    click "Log in"

    sleep 3

"create link symbolics" &&& fun _ ->

    url "http://localhost:5000/Links/Create"

    "#Link_Title" << "Symbolics"

    "#Link_Url" << "https://www.symbolics.com"

    click "Create"

    "/html/body/div/main/table/tbody/tr[2]/td[2]/a" == "Symbolics"

"take screenshot" &&& fun _ ->

    resize (850, 450)
    
    screenshot "." "screenshot-links" |> ignore

"user guy - comment" &&& fun _ ->

    url "http://localhost:5000/Links/Details?id=2"

    "/html/body/div/main/div[2]/form/div/textarea" << "Lisp Machine"

    click "Add Comment"

"user linus - comment" &&& fun _ ->

    url "http://localhost:5000/Identity/Account/Login"

    "#Input_UserName"   << "linus"

    "#Input_Password"   << "Secret123!"

    click "Log in"


    url "http://localhost:5000/Links/Details?id=2"


    click "/html/body/div/main/div[1]/dl/dd[5]/form[1]/button"

    click "/html/body/div/main/div[2]/ul/li/form[1]/button"


    click "/html/body/div/main/div[2]/ul/li/button"

    "/html/body/div/main/div[2]/ul/li/div[2]/form/div/textarea" << "Linux"

    click "/html/body/div/main/div[2]/ul/li/div[2]/form/button"


    resize (780, 870)

    screenshot "." "screenshot-comments" |> ignore

[<EntryPoint>]
let main args =
    
    run()

    quit()

    0
