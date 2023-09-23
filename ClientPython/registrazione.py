from tkinter import CENTER, Button, Entry, Frame, Label, messagebox,LabelFrame,END
import requests
import login

class Registrazione(Frame):
    def __init__(self, parent, controller):
        Frame.__init__(self, parent)
        cont = Frame(self)
        cont.pack()
        
        topFrame = Frame(cont, width=900, height=250)
        topFrame.grid(row=0,column=0,sticky="ew",padx=250)
        
        title = Label(topFrame, text="GAMETIX", font=("Helvetica", 20, "bold"),  fg="Black")
        title.grid(row = 0, column = 1, padx=50)
        
        reg = Label(cont, text="Registrazione", font=("Helvetica", 20, "bold"),  fg="Black")
        reg.grid(row=1,column=0,pady=(40,10))
        
        frameReg=LabelFrame(cont,text="Informazioni Personali")
        frameReg.grid(row=2,column=0)

        l_nome = Label(frameReg, text="Nome", font=("Helvetica", 15, "bold"),  fg="gray")
        self.nome = Entry(frameReg, font=("Helvetica", 15), bg="lightgray")
        self.nome.focus()
        l_nome.grid(row=0,column=0)
        self.nome.grid(row=1,column=0)

        l_cognome = Label(frameReg, text="Cognome", font=("Helvetica", 15, "bold"),  fg="gray")
        self.cognome = Entry(frameReg, font=("Helvetica", 15), bg="lightgray")
        l_cognome.grid(row=0,column=1)
        self.cognome.grid(row=1,column=1)

        l_societa = Label(frameReg, text="Società", font=("Helvetica", 15, "bold"),  fg="gray")
        self.societa = Entry(frameReg, font=("Helvetica", 15), bg="lightgray")
        l_societa.grid(row=0,column=2)
        self.societa.grid(row=1,column=2)

        frameAcc=LabelFrame(cont,text="Informazioni Account")
        frameAcc.grid(row=3,column=0,pady=5)
        
        l_email = Label(frameAcc, text="Email", font=("Helvetica", 15, "bold"),  fg="gray")
        self.email = Entry(frameAcc, font=("Helvetica", 15), bg="lightgray")
        l_email.grid(row=0,column=0)
        self.email.grid(row=1,column=0)
        
        l_password = Label(frameAcc, text="Password", font=("Helvetica", 15, "bold"),  fg="gray")
        self.password = Entry(frameAcc, font=("Helvetica", 15), bg="lightgray",show='*')
        l_password.grid(row=0,column=1)
        self.password.grid(row=1,column=1)

        l_conferma_password = Label(frameAcc, text="Conferma Password", font=("Helvetica", 15, "bold"),  fg="gray")
        self.conferma_password = Entry(frameAcc, font=("Helvetica", 15), bg="lightgray",show='*')
        l_conferma_password.grid(row=0,column=2)
        self.conferma_password.grid(row=1,column=2)
        
        l_log = Label(cont, text="Oppure, se sei già registrato", font=("Helvetica", 15))
        b1 = Button(cont, text="Login",  command=lambda: self.showLogin(controller),cursor="hand2",font=("Helvetica",15))
        l_log.grid(row=4,column=0,pady=(40,10))
        b1.grid(row=5,column=0,ipadx=50)

        btn_register = Button(frameAcc,  text="Registrati", command= lambda:self.funRegistrazione(controller), font=("Helvetica",19),cursor="hand2")
        btn_register.grid(row=2,column=1)
        
        for widget in frameReg.winfo_children():
            widget.grid_configure(padx=10,pady=5)

        for widget in frameAcc.winfo_children():
            widget.grid_configure(padx=10,pady=5)
    
    def showLogin(self,controller):
        self.nome.delete(0,END)
        self.cognome.delete(0,END)
        self.societa.delete(0,END)
        self.email.delete(0,END)
        self.password.delete(0,END)
        self.conferma_password.delete(0,END)
        controller.showFrame(login.LoginFrame)

    def validazioneCampi(self,form) :
        simboli = ('~','!','@','#','^','*','_','-')
        numeri = ('1','2','3','4','5','6','7','8','9','0')
        chiocciola = punto = simb= num = lunghezzaPwd = lunghezzaNome = lunghezzaCognome = lunghezzaSocieta= False
        
        #controlla che non ci siano campi vuoti
        if not form['nome']:
            return "Il campo nome è vuoto"
        if not form['cognome']:
            return "Il campo cognome è vuoto"
        if not form['societa']:
            return "Il campo società è vuoto"
        if not form['email']:
            return "Il campo email è vuoto"
        if not form['password']:
            return "Il campo password è vuoto"
        if not form['conf_password']:
            return "Il campo conferma password è vuoto"
        
        #controlla che la mail abbia il formato corretto
        if "@" in form['email']:
            chiocciola=True

        for i in range(len(form['email'])) :
            if form['email'][-3:-2] == '.' or form['email'][-4:-3] == '.':
                punto = True

        #controlla che le 2 password coincidano
        if form['password'] != form['conf_password']:
            return "Le password inserite non coincidono"

        #controlla che la password abbia almeno un simbolo ed un numero
        for i in range(len(form['password'])) :
            for j in range(len(simboli)):
                if form['password'][i] == simboli[j] :
                    simb=True
            
            for z in range(len(numeri)):
                if form['password'][i] == numeri[z] :
                    num=True


        #controlli sulle lunghezze minime dei campi del form
        if len(form['password']) > 5:
            lunghezzaPwd=True
            
        if len(form['nome']) > 2:
            lunghezzaNome=True
        
        if len(form['cognome']) > 2:
            lunghezzaCognome=True
        
        if len(form['societa']) > 2:
            lunghezzaSocieta=True

        if  chiocciola == False  or punto == False:
            return "Formato mail incorretto"
        if simb == False or num == False or lunghezzaPwd== False:
            return "La password deve contenere almeno 6 caratteri tra cui\n un numero ed un carattere speciale tra: "+str(simboli)
        if lunghezzaNome == False or lunghezzaCognome == False or lunghezzaSocieta == False:
            return "Controlla di aver inserito correttamente il tuo Nome e Cognome e la società per cui lavori"
        
        return "ok"
    
    def funRegistrazione(self,controller):
        url = 'http://localhost:8080/registra_impiegato'
        data = {
            'nome': self.nome.get(),
            'cognome': self.cognome.get(),
            'societa': self.societa.get(),
            'email': self.email.get(),
            'password': self.password.get(),
            'conf_password':self.conferma_password.get()
            }
        
        controllo = self.validazioneCampi(data)
        if controllo == 'ok':
            headers = {'Content-Type': 'application/x-www-form-urlencoded'}
            response = requests.post(url, data=data, headers=headers)

            if response.text == "successo":
                messagebox.showinfo("Successo","Account creato correttamente")
                self.showLogin(controller)
            elif response.text == "Email esistente":
                messagebox.showwarning("Errore","L'email inserita è già presente nel sistema, prova ad effettuare il login")
            elif response.text == "Errore societa":
                messagebox.showerror("Errore","La società inserita non è presente nel sistema.")
        else:
            messagebox.showwarning("Errore",controllo)

        