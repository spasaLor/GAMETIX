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
        
        b1 = Button(topFrame, text="Logout",font=("Helvetica",15),command=lambda: Landing.logout(controller,treeV),cursor="hand2")
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

        def mostraPartite():
            infoPartite=Landing.getPartite()
            treeV["columns"] = ("sport","avversario","data","ora","tipologia")
            treeV.column("#0", width=0,  stretch='no')
            treeV.column("sport",width=70,anchor='center')
            treeV.column("avversario", width=100, anchor='center')
            treeV.column("data", width=100, anchor='center')
            treeV.column("ora", width=70, anchor='center')
            treeV.column("tipologia", width=100, anchor='center')
            treeV.heading("#0",text="",anchor=CENTER)
            treeV.heading("sport",text="Sport")
            treeV.heading("avversario", text="Avversario")
            treeV.heading("data", text="Data")
            treeV.heading("ora", text="Ora")
            treeV.heading("tipologia", text="Tipologia")
            
            for i in treeV.get_children():
                treeV.delete(i)
            for partita in infoPartite:
                    treeV.insert("",END,values=(partita['Sport'],partita['Squadra_trasferta'], partita['Data'], partita['Ora'], partita['Tipologia']))

        def getInfoVendite(partita):
            url = 'http://localhost:8080/get_biglietti_partita'
            datiPost={
                'societa': app.sessione['societa'],
                'avversario': partita[1],
                'tipologia': partita[4]
            }
            headers = {'Content-Type': 'application/x-www-form-urlencoded'}
            response = requests.post(url, data=datiPost, headers=headers)
            jsn=response.json()

            info_vendite_window = Toplevel(cont)
            info_vendite_window.geometry("200x150+400+450")
            info_vendite_window.title("Info Vendite")

            Label(info_vendite_window, text="Biglietti Venduti: {}".format(jsn['Tot_Biglietti'])).pack()
            Label(info_vendite_window, text="Incasso: €{}".format(jsn['Tot_Incasso'])).pack()

        def on_double_click(event):
            item = treeV.focus()
            partita = treeV.item(item, "values")  
            getInfoVendite(partita)
        
        btnIns = Button(frameBtns,name="bottone_ins",  text="Visualizza Partite Inserite", command=mostraPartite, font=("Helvetica",15),cursor="hand2")
        btnIns.grid(row=0,column=2) 
    
        tree_frame = Frame(cont, width=200, height=200,pady=20)
        tree_frame.grid(row=3, column=0, sticky='nsew')
        treeV = Treeview(tree_frame)

        self.scroll = Scrollbar(tree_frame, orient=HORIZONTAL, command=treeV.xview)
        treeV.configure(xscrollcommand=self.scroll.set)
        tree_frame.pack_propagate(0)
        self.scroll.pack(side="bottom", fill="x")
        treeV.pack(side="top", fill="both", expand=True)
        
        treeV.bind("<Double-1>",on_double_click)
        
        for widget in frameBtns.winfo_children():
            widget.grid_configure(padx=10,pady=10)
        
        for widget in cont.winfo_children():
            widget.grid_configure(pady=10)

    def getPartite():
        if app.sessione['societa'] != "":
            url = 'http://localhost:8080/get_partite_societa'
            datiPost={
                'societa': app.sessione['societa']
            }
            headers = {'Content-Type': 'application/x-www-form-urlencoded'}
            response = requests.post(url, data=datiPost, headers=headers)
            jsn=response.json()
            return jsn

    def logout(controller,treeView):
        app.sessione['societa']=""
        app.sessione['settori']=[]
        app.sessione['loggato']=False
        for item in treeView.get_children():
            treeView.delete(item)

        controller.showFrame(login.LoginFrame)