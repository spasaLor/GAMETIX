from tkinter import Entry, Frame, Label,LabelFrame, Button, messagebox,END
import app
import requests
import landing
import login

class FrameAbbonamenti(Frame):
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

        lbl_Abb = Label(cont, text="Inserimento Prezzi Abbonamenti", font=("Helvetica", 20, "bold"),  fg="Black",pady=30)
        lbl_Abb.grid(row=1,column=1)

        self.frameBox = LabelFrame(cont,text="Informazioni Abbonamenti",pady=30)
        self.frameBox.grid(row=2,column=1)

        btnFrame=Frame(cont,pady=50)
        btnFrame.grid(row=3,column=1)
        btnSettori = Button(btnFrame,name="bottone",  text="Carica Settori", command=self.showSettori, font=("Helvetica",19),cursor="hand2")
        btnSettori.grid(row=0,column=0)
        btnInvia = Button(btnFrame,name="bottoneInv",  text="Invia Dati", command= lambda:self.aggiornaCostoAbb(controller), font=("Helvetica",19),cursor="hand2")
        btnInvia.grid(row=0,column=1)

        for widget in cont.winfo_children():
            widget.grid_configure(pady=10)

        for widget in btnFrame.winfo_children():
            widget.grid_configure(padx=10)

    def showSettori(self):
        self.l_settore1 = Label(self.frameBox, text=app.sessione['settori'][0], font=("Helvetica", 15, "bold"),  fg="gray")
        self.l_settore1.grid(row=0,column=0,padx=10,pady=5)
        self.settore1 = Entry(self.frameBox, font=("Helvetica", 15), bg="lightgray")
        self.settore1.grid(row=1,column=0,padx=10,pady=5)

        self.l_settore2 = Label(self.frameBox, text=app.sessione['settori'][1], font=("Helvetica", 15, "bold"),  fg="gray")
        self.l_settore2.grid(row=2,column=0,padx=10,pady=5)
        self.settore2 = Entry(self.frameBox, font=("Helvetica", 15), bg="lightgray")
        self.settore2.grid(row=3,column=0,padx=10,pady=5)

        self.l_settore3 = Label(self.frameBox, text=app.sessione['settori'][2], font=("Helvetica", 15, "bold"),  fg="gray")
        self.l_settore3.grid(row=0,column=1,padx=10,pady=5)
        self.settore3 = Entry(self.frameBox, font=("Helvetica", 15), bg="lightgray")
        self.settore3.grid(row=1,column=1,padx=10,pady=5)

        self.l_settore4 = Label(self.frameBox, text=app.sessione['settori'][3], font=("Helvetica", 15, "bold"),  fg="gray")
        self.l_settore4.grid(row=2,column=1,padx=10,pady=5)
        self.settore4 = Entry(self.frameBox, font=("Helvetica", 15), bg="lightgray")
        self.settore4.grid(row=3,column=1,padx=10,pady=5) 

    def aggiornaCostoAbb(self,controller):
        se1=self.settore1.get()
        se2=self.settore2.get()
        se3=self.settore3.get()
        se4=self.settore4.get()

        try:
            x = float(se1)
            y = float(se2)
            z = float(se3)
            t = float(se4)
        except ValueError:
            messagebox.showerror("Errore","Uno o più valori inseriti non consentiti")
            return

        url="http://localhost:8080/aggiorna_costo_abbonamenti"
        datiPost={
            'societa':app.sessione["societa"],
            'settore1': se1,
            'settore2': se2,
            'settore3': se3,
            'settore4': se4,
        }
        headers = {'Content-Type': 'application/x-www-form-urlencoded'}
        response = requests.post(url, data=datiPost, headers=headers)

        if response.text == "ok":
            messagebox.showinfo("Successo","Prezzi aggiornati con successo")
            controller.showFrame(landing.Landing)
            self.settore1.delete(0,END)
            self.settore2.delete(0,END)
            self.settore3.delete(0,END)
            self.settore4.delete(0,END)
        else:
            messagebox.showinfo("Errore","Qualcosa è andato storto")

    def clearPage(self):
        self.l_settore1.destroy()
        self.l_settore2.destroy()
        self.l_settore3.destroy()
        self.l_settore4.destroy()
        self.settore1.destroy()
        self.settore2.destroy()
        self.settore3.destroy()
        self.settore4.destroy()

    def logout(self,controller):
        self.clearPage()
        app.sessione['societa']=""
        app.sessione['settori']=[]
        app.sessione['loggato']=False
        controller.showFrame(login.LoginFrame)

    def back(self,controller):
        self.clearPage()
        controller.showFrame(landing.Landing)

        