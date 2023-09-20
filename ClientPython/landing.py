from tkinter import HORIZONTAL, Frame, Label,LabelFrame, Button, CENTER, Scrollbar,END,Toplevel
from tkinter.ttk import Treeview
import app
import requests
import login
import mainpage
import abbonamenti

class Landing(Frame):
    def __init__(self, parent, controller):
        Frame.__init__(self, parent)
        
        cont = Frame(self)
        cont.pack()
        
        topFrame = Frame(cont, width=900, height=250)
        topFrame.grid(row=0,column=0,sticky="ew",padx=250)
        
        b1 = Button(topFrame, text="Logout",font=("Helvetica",15),command=lambda: self.logout(controller),cursor="hand2")
        b1.grid(row = 0, column = 0)
        
        title = Label(topFrame, text="GAMETIX", font=("Helvetica", 20, "bold"),  fg="Black")
        title.grid(row = 0, column = 1, padx=50)
        
        log = Label(cont, text="Menù Gestione", font=("Helvetica", 20, "bold"),  fg="Black")
        log.grid(row=1,column=0)

        frameBtns = LabelFrame(cont,text="Attività")
        frameBtns.grid(row=2,column=0)

        btnAbb = Button(frameBtns,name="bottone_abb",  text="Gestione Abbonamenti",command= lambda: controller.showFrame(abbonamenti.FrameAbbonamenti), font=("Helvetica",15),cursor="hand2")
        btnAbb.grid(row=0,column=0) 
        
        btnPart = Button(frameBtns,name="bottone_part",  text="Gestione Partite",command=lambda: controller.showFrame(mainpage.MainPage), font=("Helvetica",15),cursor="hand2")
        btnPart.grid(row=0,column=1) 

        btnIns = Button(frameBtns,name="bottone_ins",  text="Visualizza Partite Inserite", command=self.mostraPartite, font=("Helvetica",15),cursor="hand2")
        btnIns.grid(row=0,column=2) 
    
        tree_frame = Frame(cont, width=200, height=200,pady=20)
        tree_frame.grid(row=3, column=0, sticky='nsew')
        self.treeV = Treeview(tree_frame)

        self.scroll = Scrollbar(tree_frame, orient=HORIZONTAL, command=self.treeV.xview)
        self.treeV.configure(xscrollcommand=self.scroll.set)
        tree_frame.pack_propagate(0)
        self.scroll.pack(side="bottom", fill="x")
        self.treeV.pack(side="top", fill="both", expand=True)

        self.treeV.bind("<Double-1>",self.on_double_click)
        
        for widget in frameBtns.winfo_children():
            widget.grid_configure(padx=10,pady=10)
        
        for widget in cont.winfo_children():
            widget.grid_configure(pady=10)

    def mostraPartite(self):
        url = 'http://localhost:8080/get_partite_societa'
        datiPost={
            'societa': app.sessione['societa']
        }
        headers = {'Content-Type': 'application/x-www-form-urlencoded'}
        response = requests.post(url, data=datiPost, headers=headers)
        jsn=response.json()

        self.treeV["columns"] = ("sport","avversario","data","ora","tipologia")
        self.treeV.column("#0", width=0,  stretch='no')
        self.treeV.column("sport",width=70,anchor='center')
        self.treeV.column("avversario", width=100, anchor='center')
        self.treeV.column("data", width=100, anchor='center')
        self.treeV.column("ora", width=70, anchor='center')
        self.treeV.column("tipologia", width=100, anchor='center')
        self.treeV.heading("#0",text="",anchor=CENTER)
        self.treeV.heading("sport",text="Sport")
        self.treeV.heading("avversario", text="Avversario")
        self.treeV.heading("data", text="Data")
        self.treeV.heading("ora", text="Ora")
        self.treeV.heading("tipologia", text="Tipologia")
        
        for i in self.treeV.get_children():
            self.treeV.delete(i)
        for partita in jsn:
                self.treeV.insert("",END,values=(partita['Sport'],partita['Squadra_trasferta'], partita['Data'], partita['Ora'], partita['Tipologia']))
    
    def getInfoVendite(self,partita):
        url = 'http://localhost:8080/get_biglietti_partita'
        datiPost={
            'societa': app.sessione['societa'],
            'avversario': partita[1],
            'tipologia': partita[4]
        }
        headers = {'Content-Type': 'application/x-www-form-urlencoded'}
        response = requests.post(url, data=datiPost, headers=headers)
        jsn=response.json()
        
        info_vendite_window = Toplevel(self)
        info_vendite_window.geometry("200x150+400+450")
        info_vendite_window.title("Info Vendite")

        Label(info_vendite_window, text="Biglietti Venduti: {}".format(jsn['Tot_Biglietti']),font=("Helvetica",12)).pack()
        Label(info_vendite_window, text="Incasso: €{:.2f}".format(jsn['Tot_Incasso']),font=("Helvetica",12)).pack()

    def on_double_click(self,event):
            item = self.treeV.focus()
            partita = self.treeV.item(item, "values")  
            self.getInfoVendite(partita)

    def logout(self,controller):
        app.sessione['societa']=""
        app.sessione['settori']=[]
        app.sessione['loggato']=False
        for item in self.treeV.get_children():
            self.treeV.delete(item)
        controller.showFrame(login.LoginFrame)