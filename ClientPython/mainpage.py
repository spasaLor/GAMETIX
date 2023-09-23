from tkinter import Entry, Frame, Label,LabelFrame, Button, messagebox,END
from datetime import datetime
import login
import app
import requests
import landing
   
class MainPage(Frame):

    def __init__(self, parent, controller):
        Frame.__init__(self, parent)
        
        cont = Frame(self)
        cont.pack()
        cont.columnconfigure(0,weight=1)
        cont.columnconfigure(1,weight=1)
        cont.columnconfigure(2,weight=1)
      
        b1 = Button(cont, text="Logout",font=("Helvetica",15),command=lambda: self.logout(controller),cursor="hand2")
        b1.grid(row = 0, column = 0)

        b2 = Button(cont, text="Indietro",font=("Helvetica",15),command=lambda: self.back(controller),cursor="hand2")
        b2.grid(row = 0, column = 2)

        title = Label(cont, text="GAMETIX", font=("Helvetica", 20, "bold"),  fg="Black")
        title.grid(row = 0, column = 1)

        nuovaP = Label(cont, text="Inserimento nuova Partita", font=("Helvetica", 20, "bold"),  fg="Black")
        nuovaP.grid(row=1,column=1)

        frameBox = LabelFrame(cont,text="Informazioni Partita")
        frameBox.grid(row=2,column=1)
        
        self.leftframe = Frame(frameBox,name= "leftframe")
        self.leftframe.grid(row=0,column=0)

        self.rightframe = Frame(frameBox,name= "rightframe")
        self.rightframe.grid(row=0,column=1)
        
        l_casa = Label(self.leftframe, text="Squadra in Casa", font=("Helvetica", 15, "bold"),  fg="gray")
        self.casa = Entry(self.rightframe, font=("Helvetica", 15), bg="lightgray")
        l_casa.grid(row=0,column=0)
        self.casa.grid(row=0,column=0)

        l_ospite = Label(self.leftframe, text="Squadra Ospite", font=("Helvetica", 15, "bold"),  fg="gray")
        self.ospite = Entry(self.rightframe, font=("Helvetica", 15), bg="lightgray")
        l_ospite.grid(row=1,column=0)
        self.ospite.grid(row=1,column=0)
        
        l_data = Label(self.leftframe, text="Data Partita (DD/MM/YYYY)", font=("Helvetica", 15, "bold"),  fg="gray")
        self.data = Entry(self.rightframe, font=("Helvetica", 15), bg="lightgray")
        l_data.grid(row=2,column=0)
        self.data.grid(row=2,column=0)

        l_ora = Label(self.leftframe, text="Orario partita (HH:mm)", font=("Helvetica", 15, "bold"),  fg="gray")
        self.ora = Entry(self.rightframe, font=("Helvetica", 15), bg="lightgray")
        l_ora.grid(row=3,column=0)
        self.ora.grid(row=3,column=0)

        l_tipo = Label(self.leftframe, text="Competizione", font=("Helvetica", 15, "bold"),  fg="gray")
        self.tipo = Entry(self.rightframe, font=("Helvetica", 15), bg="lightgray")
        l_tipo.grid(row=4,column=0)
        self.tipo.grid(row=4,column=0)

        btnFrame=Frame(cont)
        btnFrame.grid(row=9,column=1)
        btnSettori = Button(btnFrame,name="bottone",  text="Carica Settori", command=self.showSettori, font=("Helvetica",19),cursor="hand2")
        btnSettori.grid(row=0,column=0,padx=10)           

        btnCarica =  Button(btnFrame,  text="Invia dati Partita", command=self.caricaPartita, font=("Helvetica",19),cursor="hand2")
        btnCarica.grid(row=0,column=1,padx=10)

        for child in cont.winfo_children():
            child.grid_configure(pady=10)

        for child in frameBox.winfo_children():
            child.grid_configure(padx=10,pady=5)

        for child in self.leftframe.winfo_children():
            child.grid_configure(pady=5)

        for child in self.rightframe.winfo_children():
            child.grid_configure(pady=5)
    
    def showSettori(self):
        
        self.l_settore1 = Label(self.leftframe, text="Inserisci il prezzo per "+app.sessione['settori'][0], font=("Helvetica", 15, "bold"),  fg="gray")
        self.l_settore1.grid(row=5,column=0,pady=5)
        self.settore1 = Entry(self.rightframe, font=("Helvetica", 15), bg="lightgray")
        self.settore1.grid(row=5,column=0,pady=6)

        self.l_settore2 = Label(self.leftframe, text="Inserisci il prezzo per "+app.sessione['settori'][1], font=("Helvetica", 15, "bold"),  fg="gray")
        self.l_settore2.grid(row=6,column=0,pady=5)
        self.settore2 = Entry(self.rightframe, font=("Helvetica", 15), bg="lightgray")
        self.settore2.grid(row=6,column=0,pady=6)

        self.l_settore3 = Label(self.leftframe, text="Inserisci il prezzo per "+app.sessione['settori'][2], font=("Helvetica", 15, "bold"),  fg="gray")
        self.l_settore3.grid(row=7,column=0,pady=5)
        self.settore3 = Entry(self.rightframe, font=("Helvetica", 15), bg="lightgray")
        self.settore3.grid(row=7,column=0,pady=6)

        self.l_settore4 = Label(self.leftframe, text="Inserisci il prezzo per "+app.sessione['settori'][3], font=("Helvetica", 15, "bold"),  fg="gray")
        self.l_settore4.grid(row=8,column=0,pady=5)
        self.settore4 = Entry(self.rightframe, font=("Helvetica", 15), bg="lightgray")
        self.settore4.grid(row=8,column=0,pady=6) 

    def caricaPartita(self):
        if (self.settore1.get())==0 or len(self.settore2.get())==0 or len(self.settore3.get())==0 or len(self.settore4.get())==0:
            messagebox.showerror("Errore","Uno o più campi vuoti")
            return
        try:
            s1=float(self.settore1.get())
            s2=float(self.settore2.get())
            s3=float(self.settore3.get())
            s4=float(self.settore4.get())
        except ValueError:
            messagebox.showerror("Errore","Uno o più valori inseriti non consentiti")
            return

        url = 'http://localhost:8080/carica_partita'
        data={
            'casa': self.casa.get(),
            'ospite': self.ospite.get(),
            'data': self.data.get(),
            'ora': self.ora.get(),
            'tipo': self.tipo.get(),
            'prezzo_s1': s1,
            'prezzo_s2': s2,
            'prezzo_s3': s3,
            'prezzo_s4': s4,
        }

        controllo = self.validazioneCampi(data)
        if controllo != "ok":
            messagebox.showerror("Errore",controllo)
        else:
            headers = {'Content-Type': 'application/x-www-form-urlencoded'}
            response= requests.post(url, data=data, headers=headers)
            
            if response.text == "Partita presente":
                messagebox.showerror("Errore","Partita già presente nel database")
            elif response.text == "Squadra in casa gioca lo stesso giorno":
                messagebox.showerror("Errore","Stai inserendo due partite diverse nello stesso giorno")
            else:
                messagebox.showinfo("Successo","Partita caricata con successo")
                self.ospite.delete(0,END)
                self.data.delete(0,END)
                self.ora.delete(0,END)
                self.tipo.delete(0,END)
                self.settore1.delete(0,END)
                self.settore2.delete(0,END)
                self.settore3.delete(0,END)
                self.settore4.delete(0,END)
        
    def validazioneCampi(self,form):
        #controlla che non ci siano campi vuoti
        if len(form['casa']) == 0 or len(form['ospite'])==0 or len(form['data'])==0 or len(form['ora'])==0 or len(form['tipo'])==0:
            return "Uno o più campi vuoti"
        
        #controlla che non si sta provando ad inserire partite di una società al di fuori di quella per cui si è loggati
        if form['casa'] != app.sessione['societa']:
            return "Non puoi caricare informazioni su una partita che non è giocata in casa dalla tua società. \n Risulti impiegato presso la società: "+ app.sessione['societa']
    
        #controlla che la competizione sia corretta
        comp=["Campionato","Coppa","Coppa Europea","Amichevole"]
        if form['tipo'] not in comp:
            return "Errore nell'immissione della competizione \n - Competizioni valide: 'Campionato', 'Coppa', 'Coppa Europea'"

        #controlla che i formati di data e ora siano corretti
        try:
            date = datetime.strptime(form['data'], "%d/%m/%Y")
            time = datetime.strptime(form['ora'], "%H:%M")
            return "ok"
        except ValueError:
            return "Formato data/ora incorretto \n - Formato data corretto : DD/MM/YYYY\n - Formato ora corretto: HH:MM"

    def clearPage(self):
        self.l_settore1.destroy()
        self.l_settore2.destroy()
        self.l_settore3.destroy()
        self.l_settore4.destroy()
        self.settore1.destroy()
        self.settore2.destroy()
        self.settore3.destroy()
        self.settore4.destroy()
        self.casa.delete(0,END)
        self.ospite.delete(0,END)
        self.data.delete(0,END)
        self.ora.delete(0,END)
        self.tipo.delete(0,END)

    def logout(self,controller):
        app.sessione['societa']=""
        app.sessione['settori']=[]
        app.sessione['loggato']=False
        self.clearPage()
        controller.showFrame(login.LoginFrame)

    def back(self,controller):
        self.clearPage()
        controller.showFrame(landing.Landing)

