from tkinter import CENTER, Button, Entry, Frame, Label,LabelFrame, messagebox
import requests 
import registrazione
import app
import landing

class LoginFrame(Frame):
    def __init__(self, parent, controller):
        Frame.__init__(self, parent)
        
        cont = Frame(self)
        cont.pack()
        
        topFrame = Frame(cont, width=900, height=250)
        topFrame.grid(row=0,column=0,sticky="ew",padx=250)
        
        title = Label(topFrame, text="GAMETIX", font=("Helvetica", 20, "bold"),  fg="Black")
        title.grid(row = 0, column = 1, padx=50)
        
        log = Label(cont, text="Login", font=("Helvetica", 20, "bold"),  fg="Black")
        log.grid(row=1,column=0,pady=(40,10))

        frameLogin = LabelFrame(cont,text="Login Info")
        frameLogin.grid(row=2,column=0)

        l_email = Label(frameLogin, text="Email", font=("Helvetica", 15, "bold"))
        self.email = Entry(frameLogin, font=("Helvetica", 15),bg="lightgray")
        l_email.grid(row=0,column=0)
        self.email.grid(row=1,column=0)
        self.email.focus()
       
        l_password = Label(frameLogin, text="Password", font=("Helvetica", 15, "bold"))
        self.password = Entry(frameLogin, font=("Helvetica", 15),show="*",bg="lightgray")
        l_password.grid(row=2,column=0)
        self.password.grid(row=3,column=0)

        def funLogin():
            if len(self.email.get()) == 0 or len(self.password.get()) == 0:
                messagebox.showwarning("Errore","Uno o più campi vuoti")
                return

            url = 'http://localhost:8080/login_impiegato'

            credenziali = { 'password': self.password.get(),
                            'email': self.email.get()
                        }
            headers = {'Content-Type': 'application/x-www-form-urlencoded'}
            response = requests.post(url, data=credenziali, headers=headers)

            if response.text != "Credenziali errate":
                app.sessione['societa'] = response.text
                app.sessione['loggato'] = True
                
                url='http://localhost:8080/settori_stadio'
                data={
                    'societa': app.sessione['societa']
                }
                headers = {'Content-Type': 'application/x-www-form-urlencoded'}
                response = requests.post(url, data=data, headers=headers)
                jsn=response.json()
                
                rows=len(jsn)
                for i in range (rows): 
                    app.sessione['settori'].append(jsn[i])

                if app.sessione['loggato'] == True:
                    controller.showFrame(landing.Landing)
            else:
                messagebox.showerror("Errore",response.text)

        btn_log = Button(frameLogin,  text="Entra", command=funLogin, font=("Helvetica",19),cursor="hand2")
        btn_log.grid(row=4,column=0,sticky="ew")

        l_reg = Label(cont, text="Oppure, se non sei ancora registrato", font=("Helvetica", 15))
        b1 = Button(cont, text="Registrazione",  command=lambda: controller.showFrame(registrazione.Registrazione),cursor="hand2", font=("Helvetica", 15))        
        l_reg.grid(row=3,column=0,pady=(40,10))
        b1.grid(row=4,column=0,ipadx=50)

        for widget in frameLogin.winfo_children():
            widget.grid_configure(padx=10,pady=10)
