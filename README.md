![Build succeeded][build-shield]
![Test passing][test-shield]
[![Issues][issues-shield]][issues-url]
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
# CryptoVault

### What is this?
A quite simple but very effective application to create encrypted messages (and decrypt them) together with a strong AES encrypted password vault/manager

The application is fairly straightforward and can en-/decrypt messages without logging in.
When you launch the application you will be presented with a menu
- Encrypt
- Decrypt
- Log in

When you select log in you'll need to use the master password (which is stored as a SHA256 hash in the application itself)

### Changelog
| Version | Change |
|-|-|
| 0.0.5 | First release, en-/decrypts messages |
| 0.1.0 | Added simple menu |
| 0.1.1 | Added login to password vault |
| 0.2.0 | Added secondary "master password" for decryption |
<p align="right">(<a href="#top">back to top</a>)</p>

### Roadmap
- [x] Make a fully functional encryption service
- [x] Decrypt text using a key and cipher from other source (AES)
- [x] Make it easily expandable (prepare for web frontend etc.)
- [x] Create a password vault with secure login
- [x] Separate login password and the master password/key (Currently you *can* reverse engineer and decrypt it if you look at the src
- [ ] Add function to generate a random (secure-ish) password and add it to vault
- [ ] Make a non-console UI
- [ ] Enable encryption of files (not only text)
- [ ] Enable "Admin-mode" and the possibility of multiple users (with their own master-key and vault)
- [ ] Kill all bugs ;)

### License
* Software: GPLv3
<p align="right">(<a href="#top">back to top</a>)</p>

Special thanks to [Nicolai Heuck](https://github.com/nicolaiheuck/) for his awesome console-menu :)

### Contact

Jan Andreasen - [@andreasen_jan](https://twitter.com/andreasen_jan) - jan@tved.it

Project Link: [https://github.com/jaa2019/Crypto](https://github.com/jaa2019/Crypto)
<p align="right">(<a href="#top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[build-shield]: https://img.shields.io/badge/Build-succeeded-brightgreen.svg
[test-shield]: https://img.shields.io/badge/Tests-passing-brightgreen.svg
[contributors-shield]: https://img.shields.io/badge/Contributors-3-brightgreen.svg
[contributors-url]: https://github.com/jaa2019/Crypto/graphs/contributors
[forks-shield]: https://img.shields.io/badge/Forks-0-blue.svg
[forks-url]: https://github.com/jaa2019/Crypto/network/members
[issues-shield]: https://img.shields.io/badge/Issues-1-brightgreen.svg
[issues-url]: https://github.com/jaa2019/Crypto/issues
