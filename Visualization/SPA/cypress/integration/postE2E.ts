function randomString (strLength: any, charSet?: any) {
  let result = [];
  strLength = strLength || 5;
  charSet = charSet || 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  while (--strLength)
    result.push(charSet.charAt(Math.floor(Math.random() * charSet.length)));
  return result.join('');
}

describe('Register a new user, create new post and comment the created post', () => {
  let randomEmail = `${randomString(10)}@email.com`
  let randomPassword = randomString(10)
  let randomPhoneNumber = `+351${randomString(9, "0123456789")}`

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

  it('Login using new user credentials and create new post', () => {
    cy.visit('/')
    cy.get("#floatingInput").type(randomEmail)
    cy.get("#floatingPassword").type(randomPassword)
    cy.contains("Submit").click()
    cy.url().should("include","/network")
    cy.visit(`http://localhost:4200/profile/${randomEmail}/post`)
    cy.get("#textArea").type("Random post text")
    cy.get("#createPostButton").click()
    cy.contains("Random post text")
  })




})

