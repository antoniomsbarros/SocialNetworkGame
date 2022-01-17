function randomString (strLength: any, charSet?: any) {
  let result = [];
  strLength = strLength || 5;
  charSet = charSet || 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  while (--strLength)
    result.push(charSet.charAt(Math.floor(Math.random() * charSet.length)));
  return result.join('');
}

const randomEmail = `${randomString(10)}@email.com`
const randomPassword = randomString(10)
const randomPhoneNumber = `+351${randomString(9, "0123456789")}`

describe('Register a new user and login using new credentials', () => {
  it('Visits the initial project page and verifies that login form exists', () => {
    cy.visit('/')
    cy.url().should("include","/login")
    cy.title().should("eq", "Social Network Game")
    cy.contains("Hi, welcome back!")
    cy.get('input').should('have.length', 2)
    cy.get('button').should('have.length', 1).contains("Submit")
  })

  it('Visits the initial project page and creates a new user through the sign up form', () => {
    cy.visit('/')
    cy.contains("Create an account").click()
    cy.url().should("include","/signin")
    cy.contains("Sign up")
    cy.get("#id_email").type(randomEmail)
    cy.get("#id_number").type(randomPhoneNumber)
    cy.get("#id_dateOfBirth").type("1990-12-12")
    cy.get("#id_emotionalStatus").select("Relieve")
    cy.get("#id_fullName").type("Name")
    cy.get("#id_lastName").type("Name")
    cy.get("#id_Password").type(randomPassword)
    cy.get("#id_PasswordConfirmation").type(randomPassword)
    cy.get("#id_termsConditions").check()
    cy.contains("Register").click()
    cy.url().should("include","/login")
  })

  it('Visits the initial project page and login using new user credentials', () => {
    cy.visit('/')
    cy.get("#floatingInput").type(randomEmail)
    cy.get("#floatingPassword").type(randomPassword)
    cy.contains("Submit").click()
    cy.url().should("include","/network")

  })

})

