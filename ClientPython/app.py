import login
import registrazione
import mainpage
import landing
import abbonamenti
from tkinter import Frame, Tk

sessione={
    'settori': [],
    'societa': "",
    'loggato':False
}

class Gametix(Tk):
    def __init__(self, *args, **kwargs):
        Tk.__init__(self, *args, **kwargs)

        self.wm_title("GAMETIX")
        self.geometry("900x600+300+100")
        container = Frame(self, height=900, width=600)
        container.pack(side="top", fill="both", expand=True)
        container.grid_rowconfigure(0, weight=1)
        container.grid_columnconfigure(0, weight=1)

        self.frames = {}

        for F in (login.LoginFrame, registrazione.Registrazione, mainpage.MainPage,landing.Landing,abbonamenti.FrameAbbonamenti):
            frame = F(container, self)
            self.frames[F] = frame
            frame.grid(row=0, column=0, sticky="nsew")
            
        self.showFrame(login.LoginFrame)
        
    def showFrame(self, cont):
        frame = self.frames[cont]
        frame.tkraise()

if __name__ == "__main__":
    app = Gametix()
    app.mainloop()
    