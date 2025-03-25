# Boardroom Booking System for RSI

## Introduction

The purpose of this application serves as the foundation for the company intranet, with additional functionality to be added in the future.

## Security

- **Log In**: Users must log in with their RSI email address which is validated by their domain name.
- Ability to save passwords to this device
- Ability to remian logged in on their device

## General

- The system will be deployable on RSI’s server with MS SQL Server and web-enabled.
- It is be functional across all screen resolutions.
- The system is mobile-friendly.

## Functionality

### Administrator Rights

- **Create Boardrooms**:
  - Two types of boardrooms:
    - Client boardrooms
    - Internal boardrooms
  - Ability to name a boardroom.
- **Add a User**:
  - Name & surname
  - Email address
  - Select a user’s manager
  - After adding a user, an email is sent to the user to set their password.
- **Set Boardroom Type**:
  - Administrators can set a meeting room as internal or client.
- Administrators also have user rights.

### User Rights

- **Create a Password**: Users can create their own password.
- **Update Password**: Users can update their password.
- **Book a Meeting Room**:
  - Rooms can be booked for specific dates and times, in 15-minute intervals.
  - Client meeting rooms require the inclusion of a client name.
  - Internal rooms do not require a client name for booking.
