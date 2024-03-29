class Computer {

    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = +ramMemory;
        this.cpuGHz = +cpuGHz;
        this.hddMemory = +hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
    };

    installAProgram(name, requiredSpace) {

        // If not enough HDD space
        if (+requiredSpace > this.hddMemory) {
            throw new Error(`There is not enough space on the hard drive`);
        };

        //If enough new{} => installedPrograms => ({name}, {requiredSpace} => hddMemory -= requiredSpace
        let newProgram = {
            name: name,
            requiredSpace: +requiredSpace
        };

        this.installedPrograms.push(newProgram);

        this.hddMemory -= requiredSpace;

        return newProgram;
    };

    uninstallAProgram(name) {

        let programFound = false;

        this.installedPrograms.forEach(program => {

            if (program.name === name) {
                this.hddMemory += program.requiredSpace;

                let indexOfTheProgram = this.installedPrograms.indexOf(program);

                this.installedPrograms.splice(indexOfTheProgram, 1);

                programFound = true;
            };
        });

        if (programFound) {
            return this.installedPrograms;
        } else {
            //If no installed programs with  name => error thrown:"Control panel is not responding"
            throw new Error(`Control panel is not responding`);
        };
    };

    openAProgram(name) {

        let programFound = false;
        let alreadyOpen = false;
  
        let runningProgram = {};

        // For All Installed Programs
        this.installedPrograms.forEach(program => {

            // If Program is found => run it
            if (program.name === name) {

                // If program is already running
                if (alreadyOpen) {
                    throw new Error(`The ${name} is already open`);
                }

                programFound = true;

                //Calculate needed PC recources
                let memoryToUseInPercent = (program.requiredSpace / this.ramMemory) * 1.5;
                let cpuToUseInPercent = ((program.requiredSpace / this.cpuGHz) / 500) * 1.5;

                //Run the App
                runningProgram.name = name;
                runningProgram.ramUsage = memoryToUseInPercent;
                runningProgram.cpuUsage = cpuToUseInPercent;
                this.taskManager.push(runningProgram);
                alreadyOpen = true;
            }
        });

        if (programFound) {
            return runningProgram
        } else {
            throw new Error(`The ${name} is not recognized`);
        }
    };

    taskManagerView() {

        if (this.taskManager.length === 0) {
            return `All running smooth so far`;
        } else {
            let result = ``;

            this.taskManager.forEach(program => {
                result += `Name - ${program.name} | Usage - CPU: ${program.cpuUsage.toFixed(0)}%, RAM: ${program.ramUsage.toFixed(0)}%\n`;
            });

            return result.trim();
        }
    };
}


// Zero Test - Task Manager View

// arrange
let computer = new Computer(4096, 7.5, 250000);

// act
computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 12288);
computer.installAProgram('Solitare', 1500);

computer.openAProgram('Word');
computer.openAProgram('Excel');
computer.openAProgram('PowerPoint');
computer.openAProgram('Solitare');

console.log(computer.taskManagerView());