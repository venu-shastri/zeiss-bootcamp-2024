# zeiss-bootcamp-2024
## User Story 1:

Customer Theory

Financial Risk System
             A global investment bank based in India, New York and Singapore trades (buys and sells) financial products with other banks (“counterparties"). When share prices on the stock markets move up or down, the bank either makes money or loses it. At the end of the working day, the bank needs to gain a view of how much risk of losing money they are exposed to, by running some calculations on the data held about their trades. The bank has an existing Trade Data System (TDS) and Reference Data System (RDS) but needs a new Risk System.

Trade Data System (TDS)
The Trade Data System maintains a store of all trades made by the bank. It is already configured to generate a file-based XML export on a network share of trade data at the close of business (5pm) in NewYork. The export includes the following information for every trade made by the bank: 
• Trade ID, Date, Current trade value in US dollars, Counterparty ID
Reference Data System (RDS)
The Reference Data System maintains all of the reference data needed by the bank. This includes
Information about counterparties; each of which represents an individual, a bank, etc. A file-based XML
Export is also available on a network share and includes basic information about each counterparty. A new organization-wide reference data system is due for completion in the next 3 months, with the current system eventually being decommissioned

The high-level requirements for the new Risk System are as follows.
 Import trade data from the Trade Data System and Import counterparty data from the Reference Data System. Join the two sets of data together, enriching the trade data with information about the Counterparty, for each counterparty, calculate the risk that the bank is exposed to.  Generate a report that can be imported into Microsoft Excel containing the risk figures for all counterparties known by the bank.
 Distribute the report to the business users before the start of the next trading day (9am) in
Singapore. Provide a way for a subset of the business users to configure and maintain the external parameters used by the risk calculations.

## User Story 2:
### CNC Monitoring and Alerting

We need a solution to interpret data coming out of a _CNC-machine monitor_.
Our purpose is to alert when something needs attention.
The alert needs to include information on the area that needs attention -
the machine or the environment.
The personnel that need to be alerted are different in each case.

A basic idea of CNC machines can be seen [here](https://en.wikipedia.org/wiki/Numerical_control).
Keeping these machines safe and reliable is vital in any manufacturing unit.

### Monitored data

The _CNC-machine monitor_ gives the following data:

- Operating temperature: Temperature around the CNC machine in Celsius.
Reported every half-hour. Need to alert if it goes beyond 35 degrees.

- Part-dimension variation: In mm. A variation of more than 0.05 mm needs attention
(example: a drill-bit in the machine may need replacement)

- Duration of continuous operation: Reported in minutes.
Updated once every 15 minutes.
More than 6 hours of continuous operation requires attention.

- Self-test status-code, reported at startup

| Code | Meaning                                                      |
| ---: | ------------------------------------------------------------ |
| 0xFF | All ok                                                       |
| 0x00 | No data (examples: no power, no connection to the data-collector) |
| 0x01 | Controller board in the machine is not ok                    |
| 0x02 | Configuration data in the machine is corrupted               |

Assume that the above data is monitored and passed-on to your program.
You can choose to take the inputs as function calls to your program, or as events.

### Expected outputs

The program needs to indicate if there is a need for attention.

When there is a need to attend,
it needs to offer an initial diagnosis,
to help in alerting the appropriate personnel:
It needs to convey whether the machine needs attention,
or if its environment needs attention.


