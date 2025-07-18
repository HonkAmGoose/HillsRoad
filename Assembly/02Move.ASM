; ---------------------------------------------------------------
; A program to demonstrate MOV, LDR and STR commands.
; MOV is short for Move. Supports Immediate and Direct(Register to Register) addressing modes
; LDR is short for Load Register. Direct mode from memory only.
; STR is short for Store Register. Direct mode to memory only.
; ---------------------------------------------------------------
	CLO		; Close unwanted windows.
; ===== IMMEDIATE MOVES =====
	MOV	R0,#15	; Copy 15 into the R0 register
	MOV	R1,#40	; Copy 40 into the R1 register
	MOV	R2,#50	; Copy 50 into the R2 register
	MOV	R3,#60	; Copy 60 into the R3 register


; ===== STORE =====
	STR	R0,32	; Copy value in R0 to RAM location 32

; ===== REGISTER TO REGISTER DIRECT MOVE =====
	MOV	R0,R1	; Copy the value in R1 to R0

; ===== LOAD =====
	LDR	R1,32	; Copy value in RAM location 32 into R1
	
	END
; ---------------------------------------------------------------
	TASK
	====
	Look up the ASCII codes of the letters in H,E,L,L,O and move these ASCII codes
	to RAM addresses C0, C1, C2, C3 and C4 (-64,-63,-62,-61,-60 in decimal).
 
	The program you write should work but if you continue to study low level programming, 
	you will find much more efficient and flexible ways of solving this problem.

